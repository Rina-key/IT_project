document.addEventListener('DOMContentLoaded', function () {
    const form = document.querySelector('form');

    form.addEventListener('submit', async function (e) {
        e.preventDefault();

        const formData = {
            username: form.elements.username.value,
            email: form.elements.email.value,
            password: form.elements.password.value
        };

        try {
            const response = await fetch('/Auth/reg', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(formData)
            });

            const result = await response.json();
            if (result.success) {
                window.location.href = result.redirectUrl;
            } else {
                alert(result.error);
            }
        } catch (error) {
            console.error(error);
        }
    });
});