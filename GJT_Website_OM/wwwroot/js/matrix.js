window.onload = function () {
    const canvas = document.getElementById('Matrix');
    if (canvas) {
        const context = canvas.getContext('2d');

        // Ensure canvas is full screen
        canvas.width = window.innerWidth;
        canvas.height = window.innerHeight;

        // Draw "Not Implemented" text in the center
        const drawCenterText = () => {
            context.fillStyle = "white";
            context.font = "50px Arial";
            context.textAlign = "center";
            context.textBaseline = "middle";
            context.fillText("Not Implemented", canvas.width / 2, canvas.height / 2);
        };

        // Draw the Matrix animation
        const katakana = 'アァカサタナハマヤャラワガザダバパイィキシチニヒミリヰギジヂビピウゥクスツヌフムユュルグズブヅプエェケセテネヘメレヱゲゼデベペオォコソトノホモヨョロヲゴゾドボポヴッン';
        const latin = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
        const nums = '0123456789';
        const fontSize = 16;
        const columns = canvas.width / fontSize;
        const rainDrops = [];

        for (let x = 0; x < columns; x++) {
            rainDrops[x] = 1;
        }

        const alphabet = katakana + latin + nums;

        const draw = () => {
            context.fillStyle = 'rgba(0, 0, 0, 0.05)';
            context.fillRect(0, 0, canvas.width, canvas.height);

            context.fillStyle = '#0F0';
            context.font = fontSize + 'px monospace';

            for (let i = 0; i < rainDrops.length; i++) {
                const text = alphabet.charAt(Math.floor(Math.random() * alphabet.length));
                context.fillText(text, i * fontSize, rainDrops[i] * fontSize);

                if (rainDrops[i] * fontSize > canvas.height && Math.random() > 0.975) {
                    rainDrops[i] = 0;
                }
                rainDrops[i]++;
            }

            drawCenterText(); // Draw the "Not Implemented" text
        };

        setInterval(draw, 30);
    } else {
        console.error('Canvas element with id "Matrix" not found.');
    }
};
