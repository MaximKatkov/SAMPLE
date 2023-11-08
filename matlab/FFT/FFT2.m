function X = FFT2(x)
 
    N = length(x);
    N_half = N/2;
    m = (0:1:N_half-1)';

    a1=0;a2=0;b1=0;b2=0;

    for n = 0:N_half-1

            a1 = a1 + (cos_compnt( x(2*n+1), n, m, (N/2) ));
            a2 = a2 + (cos_compnt( x(2*n + 2), (1+2*n), m, N ));

            b1 = b1 + (sin_compnt( x(2*n+1), n, m, (N/2) ));
            b2 = b2 + (sin_compnt( x(2*n + 2), (1+2*n), m, N ));

    end

    X = ((( + a1 + a2)).^2 + (( - b1 - b2)).^2).^(0.5);

end