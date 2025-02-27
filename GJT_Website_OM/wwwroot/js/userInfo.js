window.getBrowserInfo = function () {
    return navigator.userAgent;
}

window.getScreenResolution = function () {
    return window.screen.width + "x" + window.screen.height;
}

window.getLanguage = function () {
    return navigator.language || navigator.userLanguage;
}

window.getUserAgent = function () {
    return navigator.userAgent;
}

window.getDeviceType = function () {
    const ua = navigator.userAgent;
    if (/Mobile|Android|iPhone|iPad|iPod/.test(ua)) {
        return 'Mobile';
    } else {
        return 'Desktop';
    }
}

window.getGeoLocation = function () {
    return new Promise((resolve, reject) => {
        navigator.geolocation.getCurrentPosition(
            position => {
                resolve(position.coords.latitude + ", " + position.coords.longitude);
            },
            error => {
                reject(error);
            }
        );
    });
}

window.getWiFiNetwork = function () {
    // Not easily accessible via browser; placeholder
    return "Not available";
}

window.getInternetConnectionType = function () {
    // Not easily accessible via browser; placeholder
    return "Wired";
}

window.getTimeZone = function () {
    return Intl.DateTimeFormat().resolvedOptions().timeZone;
}

window.getBatteryStatus = async function () {
    const battery = await navigator.getBattery();
    return `${battery.level * 100}%`;
};

window.getScreenBrightness = function () {
    // Screen brightness can be tricky to access directly, but if available, it might be through device API
    return "Unavailable"; // Example, as screen brightness info may not be available
};

window.getRemainingApiRequests = function () {
    // Example: Track API rate limiting from the server or API responses
    return 3678;  // Dummy data, replace with actual API rate limit logic
};

window.getRateLimitResetTime = function () {
    // Example: Fetch the rate limit reset time
    return "2025-12-31 23:59:59";  // Dummy data
};

window.getLocalStorageData = function () {
    return JSON.stringify(localStorage);
};

window.getSessionStorageData = function () {
    return JSON.stringify(sessionStorage);
};

window.getDownloadSpeed = function () {
    // This might require additional setup, like measuring network speed
    return "78 Mbps"; // Dummy data, replace with actual network speed logic
};

window.getUploadSpeed = function () {
    // This might require additional setup, like measuring network speed
    return "16 Mbps"; // Dummy data
};

window.getNetworkLatency = function () {
    // This might require additional setup, like measuring network latency
    return "7 ms"; // Dummy data
};

