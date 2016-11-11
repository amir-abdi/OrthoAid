function [sp_x,C]=contour_trace(BW,row,col)
% 
% File Name  : contour_trace.m
% Author     : Anoop Sadani
% Written On : 18-Feb-04
%
% Contour Tracing of a Black White Image (Binary Image).
%
% Assuming Foreground to be in Black and Background to be in White, this
% function traces the entire contour and requires row and column value of any 
% pixel which lies on the contour and returns the (row,column) values of all the
% points which lie on the contour. 
%
% This can be used in Line Following Algorithms also. 
%
% Syntax : 
% [pixel,I]=contour_trace(BW,r,c)
%
%   Input :
%   r,c - row, column value of a single pixel on the contour.
%   BW - Black & White Image (Binary Image).
%
%   Output : 
%   I - Binary Image containing just the desired contour.
%   pixel - N x 2 matrix which stores the pixel value of the contour,
%           column1 gives the rows & column2 the corresponding column.
% 
k=1;loop=0;
C(1:size(BW,1),1:size(BW,2))=255;      
sp_x(1,2)=col;sp_x(1,1)=row;

while(1)
    prev_size=size(sp_x,1);
    while(1)
        loop=loop+1;        
        if ((sp_x(loop,1)-1)>=1 && (sp_x(loop,2)-1)>=1)
            if (BW((sp_x(loop,1)-1),(sp_x(loop,2)-1))==0)
                k=k+1;
                sp_x(k,2)=sp_x(loop,2)-1;
                sp_x(k,1)=sp_x(loop,1)-1;
                BW((sp_x(loop,1)-1),(sp_x(loop,2)-1))=1;
            end
        end
        
        if ((sp_x(loop,1))>=1 && (sp_x(loop,2)-1)>=1)        
            if (BW((sp_x(loop,1)),(sp_x(loop,2)-1))==0)
                k=k+1;
                sp_x(k,2)=sp_x(loop,2)-1;
                sp_x(k,1)=sp_x(loop,1);
                BW((sp_x(loop,1)),(sp_x(loop,2)-1))=1;
            end
        end
        
        
        if ((sp_x(loop,1)+1)>=1 && ((sp_x(loop,2)-1)>=1))
            if (BW((sp_x(loop,1)+1),(sp_x(loop,2)-1))==0)
                k=k+1;
                sp_x(k,2)=sp_x(loop,2)-1;
                sp_x(k,1)=sp_x(loop,1)+1;
                BW((sp_x(loop,1)+1),(sp_x(loop,2)-1))=1;
            end
        end
        
        
        if ((sp_x(loop,1)-1)>=1 && ((sp_x(loop,2)+1)>=1))        
            if (BW((sp_x(loop,1)-1),(sp_x(loop,2)+1))==0)
                k=k+1;
                sp_x(k,2)=sp_x(loop,2)+1;
                sp_x(k,1)=sp_x(loop,1)-1;
                BW((sp_x(loop,1)-1),(sp_x(loop,2)+1))=1;
            end
        end
        
        if ((sp_x(loop,1))>=1 && ((sp_x(loop,2)+1)>=1))    
            if (BW((sp_x(loop,1)),(sp_x(loop,2)+1))==0)
                k=k+1;
                sp_x(k,2)=sp_x(loop,2)+1;
                sp_x(k,1)=sp_x(loop,1);
                BW((sp_x(loop,1)),(sp_x(loop,2)+1))=1;
            end
        end
        
        
        if ((sp_x(loop,1)+1)>=1 && ((sp_x(loop,2)+1)>=1))    
            if (BW((sp_x(loop,1)+1),(sp_x(loop,2)+1))==0)
                k=k+1;
                sp_x(k,2)=sp_x(loop,2)+1;
                sp_x(k,1)=sp_x(loop,1)+1;
                BW((sp_x(loop,1)+1),(sp_x(loop,2)+1))=1;
            end
        end
        
        
        if ((sp_x(loop,1)+1)>=1 && ((sp_x(loop,2))>=1))        
            if (BW((sp_x(loop,1)+1),(sp_x(loop,2)))==0)
                k=k+1;
                sp_x(k,2)=sp_x(loop,2);
                sp_x(k,1)=sp_x(loop,1)+1;
                BW((sp_x(loop,1)+1),(sp_x(loop,2)))=1;
            end
        end
        
        
        if ((sp_x(loop,1)-1)>=1 && ((sp_x(loop,2))>=1))    
            if (BW((sp_x(loop,1)-1),(sp_x(loop,2)))==0)
                k=k+1;
                sp_x(k,2)=sp_x(loop,2);
                sp_x(k,1)=sp_x(loop,1)-1;
                BW((sp_x(loop,1)-1),(sp_x(loop,2)))=1;
            end
        end
        
        
        
        if (loop>=prev_size)
            break;
        end                   
    end % end of while 
    
    if (prev_size==size(sp_x,1))
        break;
    end        
end % end of while 
for loop=1:size(sp_x,1)
    C(sp_x(loop,1),sp_x(loop,2))=0;
end    
C=uint8(C);






