function y = generate_sine_wave(freq, sample_rate, duration)
    x = linspace(0, duration, sample_rate*duration);
    frequencies = x * freq;
    % 2pi ��� �������������� � �������
    y = sin((2 * pi) * frequencies);