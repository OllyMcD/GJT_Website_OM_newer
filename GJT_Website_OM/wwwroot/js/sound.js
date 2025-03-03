window.playAudio = function () {
    let audio = document.getElementById("myAudio");

    if (audio) {
        let playPromise = audio.play();

        if (playPromise !== undefined) {
            playPromise
                .then(() => console.log("Audio playing"))
                .catch(error => console.error("Autoplay failed:", error));
        }
    } else {
        console.error("Audio element not found");
    }
};
