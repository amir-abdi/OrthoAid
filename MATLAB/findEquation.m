clc
clear all
close all

src_fld = 'NewSeparatedWires/';
dst_fld = 'NewPolynomials/';
mkdir (dst_fld);
files = dir([src_fld '*.bmp']);

se = strel('ball', 1,1);
for i = 1 : numel(files)    
    im = imread([src_fld files(i).name]);    
%     figure; imshow(im);
    
    mask = im2bw(im, 0.8);
    mask = imcomplement(mask);
    mask = bwmorph(mask, 'close');
    %     mask = imerode(mask, se);
%     mask = im2bw(mask, 'clean');
    
    mask = bwmorph(mask, 'thin', Inf);
    im = mask;
%     figure; imshow(mask);
    %% line tracing    
    [rows,cols] = find(im);
    points = [];
    [~,ind] = min((size(im,1)-rows).^2 + (1-cols).^2);
    queue = [rows(ind), cols(ind)];
    
    n = 1;
%     filename = 'linetracing.gif';
    mask = false(size(im));
    %// While the queue is not empty    
    while ~isempty(queue)

        %// Dequeue
        pt = queue(1,:);
        queue(1,:) = [];
        
        
        %// If this is not a valid vessel point, mark as visited and continue
        if im(pt(1),pt(2)) == 0
            mask(pt(1),pt(2)) = true;    

        %// If we have visited this point, continue
        elseif mask(pt(1),pt(2))
            continue;        
        else
            %// We haven't visited this point yet
            %// Mark this as visited
            mask(pt(1),pt(2)) = true;
            points(n,1) = pt(1);
            points(n,2) = pt(2);
            
            n = n + 1;

            %// Find neighbouring points that surround current point
            %// and only select those that we haven't visited
            [c,r] = meshgrid(pt(2)-1:pt(2)+1,pt(1)-1:pt(1)+1);
            ind = sub2ind(size(im), r, c);
            locs = im(ind);
            r = r(locs);
            c = c(locs)   ;

            %// Enqueue
            queue = [queue; r(:) c(:)];
        end
    end  
    
    %% scale curve to measurements
    dist_image = sqrt((points(1,1)-points(end,1))^2 + ...
            (points(1,2)-points(end,2))^2 );
    strs = strsplit(files(i).name(1:end-4), '_');    
    dist_measure = str2num(strs{3});
    scale_factor = dist_measure/dist_image;
    points = points.*scale_factor;
    new_dist_image = sqrt((points(1,1)-points(end,1))^2 + ...
            (points(1,2)-points(end,2))^2 )
    %% spline fit
    x = points(:,2);
    y = points(:,1);
%     pp = spline(y,x);
    smoothSpan = 0.08;
    x = smooth(x, smoothSpan, 'lowess');
    y = smooth(y, smoothSpan, 'lowess');
    t = cumsum(sqrt([0;diff(x)].^2 + [0;diff(y)].^2));
    
    degree = 12;  
    % ******** important commnets ********%
    % degree above 12, C# become unstable
    %if I go beyond 15, the C# code crashes!
    fitx = polyfit(t,x,degree);    
    tt = min(t):max(t);
    xx = polyval(fitx, tt);
    figure(1);
    plot(tt, xx, 'r');
    hold on; 
    plot(t, x, 'g');
    hold off;
        
    fity = polyfit(t,y,degree);        
    yy = polyval(fity, tt);
    
    %%
    TT = zeros(numel(tt), degree+1);
    for pow = 0:degree
        TT(:,pow+1) = tt.^(pow);
    end
    
    XX = TT * fliplr(fitx)';
    YY = TT * fliplr(fity)';
    %%
    
    figure(2);
    plot(tt, yy, 'r');
    hold on; 
    plot(t, y, 'g');
    hold off;
%     fity = fit(t,y, 'smoothingspline');

%%
    figure(3);
    plot(xx,yy, 'r')
    hold on;
    plot (x,y, 'g')
    hold off;

    
    %%
    fileid = fopen([dst_fld strs{1} '_' strs{2} '.txt'], 'w');    
    fprintf(fileid, '%d', degree);   
    fprintf(fileid, '\n');
    fprintf(fileid, '%d ', fliplr(fitx));   
    fprintf(fileid, '\n');
    fprintf(fileid, '%d ', fliplr(fity));   
    fprintf(fileid, '\n');
    fprintf(fileid, '%d',  min(t));   
    fprintf(fileid, '\n');
    fprintf(fileid, '%d', max(t));   
    fprintf(fileid, '\n\n degree \n x = f(t) \n y = f(t) \n min(t) \n max(t)');
    fclose(fileid);
        
end


