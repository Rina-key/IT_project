// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("loginForm");

    form.addEventListener("submit", async (e) => {
        e.preventDefault();
        const username = document.getElementById("username").value;
        const password = document.getElementById("password").value;

        const user = {
            username: username,
            password: password
        }

        try {
            const response = await fetch("api/auth/login", {
                method: 'POST',
                body: JSON.stringify(user);
            });
            if (!response.ok) {
                alert("Неверный логин или пароль");
            }
        }
    });
});