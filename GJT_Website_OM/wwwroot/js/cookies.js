// wwwroot/cookies.js

// Set a cookie with a specified name, value, and expiration days
window.setCookie = (name, value, days) => {
    const date = new Date();
    date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000)); // Set expiration time
    const expires = "expires=" + date.toUTCString();
    document.cookie = name + "=" + value + ";" + expires + ";path=/"; // Create the cookie
};

// Get the value of a cookie by its name
window.getCookie = (name) => {
    const nameEQ = name + "=";
    const ca = document.cookie.split(';'); // Split cookies into an array
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i].trim();
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length); // Return cookie value
    }
    return "";
};

// Delete a cookie by its name
window.deleteCookie = (name) => {
    document.cookie = name + "=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/"; // Set an expired date
};

// Apply the theme (dark, light or high contrast) by modifying the body class
window.applyTheme = function (themeClass) {
    document.body.classList.remove("dark-mode", "light-mode", "high-contrast");
    document.body.classList.add(themeClass);
};
