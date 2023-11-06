clear
clc
% ������ ���������� �����. �������� �������� ������ � ��������������� �����,
% � ����� ������ ��� � ������� �������������� �����.

% SAMPLE_RATE = 2000 ;  %������� ������������� (����-�� ��������)
% DURATION = 1 ; % ������������ ������� (���)
% 
% nice_tone = generate_sine_wave(100, SAMPLE_RATE, DURATION);
% noise_tone = generate_sine_wave(700, SAMPLE_RATE, DURATION);
% noise_tone2 = generate_sine_wave(1000, SAMPLE_RATE, DURATION);
% 
% noise_tone = noise_tone * 0.3;
% noise_tone2 = noise_tone2 * 0.2;
% mixed_tone = nice_tone + noise_tone + noise_tone2;
% 
% % ������������, ��������������� ������� ��� ������� ������. 
% % � ����� ������ ��� 16-������ ����� �����, ����� ��������� 
% % ����� �������� � ��������� �� -32768 �� 32767
% 
% normalized_tone = ((mixed_tone / max(mixed_tone)) * 32767);

normalized_tone = BPSK_modulatorclc(2e6);

figure(1)
    plot(normalized_tone,'g');
    title('Signal');
    xlabel('X');
    ylabel('Y');

SAMPLE_RATE = length(normalized_tone);
fprintf(' ������� �������������,(����-�� ��������) = %d.\n' , SAMPLE_RATE);
% ��������� ������� �� FFT � ���������� ������� fft

% Y = FFT(normalized_tone);
% %y = fft(normalized_tone);
% 
 xf_half = linspace(0, SAMPLE_RATE/2, SAMPLE_RATE/2 );
% xf = cat(2, xf_half, linspace(-(SAMPLE_RATE/2) , 0, (SAMPLE_RATE/2)));
% 
% figure(2)
% %     plot(xf,Y,xf,abs(y));
% plot(xf,Y, '*-');
% hold on
% %plot(xf,abs(y));
% title('Spectrum');
% xlabel('f');
% ylabel('S(f)');
    
% ��������� ������� (� ������������� ������� ������) �� FFT2 

Y_half = FFT2(normalized_tone);

max_Ampldt = max(Y_half);
fprintf(' ������������ ��������� = %d.\n' , max_Ampldt);

index_f = find(Y_half == max_Ampldt);
fprintf(' C������������� ������� = %d.\n' ,xf_half(index_f));

figure(3)
    plot(xf_half,Y_half,'b+-');
    title('Spectrum');
    xlabel('f');
    ylabel('S(f)');
    
% % ����� ������ ���������� ����� 
% % ���� �� ��������� �������� ���� ������ ����, ��������������� ������� 
% % ���������� �������������� � �������������� ������� �� ��������� �������
%     
% % ������������ ������� ���������� �������� ������� �������������
% points_per_freq = length(xf_half) / (SAMPLE_RATE / 2);
% 
% % ���� ������� ������� - 700 �� � 100 ��
% target_idx = (points_per_freq * 700);
% target_idx2 = (points_per_freq * 1000);
% 
% % ������� Y_half ��� �������� ����� ������� ������� (+/- 30(� ��. xf_half))
% 
% Y_half(target_idx-30:target_idx+30) = 0 ;
% Y_half(target_idx2-30:target_idx2+30) = 0 ;
% 
% figure(4)
%     plot(xf_half,Y_half);
%     title('Spectrum');
%     xlabel('f');
%     ylabel('S(f)');
%     
% % �������� �������� �������������� �����, ������� ����������� ��� ������
% % �� ��������� �������
% 
% X_half = ifft(Y_half);
% 
% t = (0:length(X_half)-1);
% 
% figure(5)
%     plot(t,X_half);
%     title('Signal');
%     xlabel('X');
%     ylabel('Y');
    
  



