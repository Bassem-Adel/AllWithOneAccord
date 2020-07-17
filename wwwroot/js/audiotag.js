(function () {
    window.audioTag = {
        init: function init(elem, componentInstance) {
            elem.load();
            elem.addEventListener('timeupdate', function handleTimeChange(event) {
                if (elem) {
                    componentInstance.invokeMethodAsync('NotifyChange', elem.currentTime).then(null, function (err) {
                        throw new Error(err);
                    });
                }
            });
            elem.addEventListener('play', function handlePlayChange(event) {
                componentInstance.invokeMethodAsync('PausedChange', elem.paused).then(null, function (err) {
                    throw new Error(err);
                });
            });
            elem.addEventListener('pause', function handlePauseChange(event) {
                componentInstance.invokeMethodAsync('PausedChange', elem.paused).then(null, function (err) {
                    throw new Error(err);
                });
            });
            elem.player = new Plyr(elem, {
                settings: [],
            });
        },

        seekto: function seekto(time ,elem) {
            if (!isNaN(elem.duration))
                elem.currentTime = time;
        },
        load: function load(elem) {
            if (!isNaN(elem.duration))
                elem.load();
        },
        play: function play(elem) {
            elem.play();
        },
        pause: function pause(elem) {
            elem.pause();
        },
        dispose: function dispose(elem) {
            elem.player.destroy();
        },
    };
})();