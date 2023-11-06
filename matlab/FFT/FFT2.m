function X = FFT2(x)
 
    N = length(x);
    N_half = N/2;
    Pi = 3.141592653589793;
    XRe = zeros(1,N_half);
    XIm = zeros(1,N_half);
    X = zeros(1,N_half);

    for m = 0:N_half-1

        for n = 0:N_half-1

            a1 = cos_compnt( x(2*n+1), n, m, (N/2), Pi );
            a2 = cos_compnt( x(2*n + 2), (1+2*n), m, N, Pi );
                
            b1 = sin_compnt( x(2*n+1), n, m, (N/2), Pi );
            b2 = sin_compnt( x(2*n + 2), (1+2*n), m, N, Pi );
            
            XRe(m+1) = XRe(m+1) + a1 + a2;
            XIm(m+1) = XIm(m+1) - b1 - b2;  

        end

        X(m+1) = sqrt((XRe(m+1))^2 + (XIm(m+1))^2);

    end   