// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const cards = document.querySelectorAll('.card');
    cards.forEach(card => {
        card.addEventListener('click', async function() {
            

            try {
                // Отправляем GET запрос с категорией в query параметре
                //const response = await fetch(`/api/items?category=${encodeURIComponent(category)}`);
                //const response = await fetch(`/Send/${card.dataset.name}`);
                //if (!response.ok) {
                //    throw new Error(`Ошибка HTTP: ${response.status}`);
                //}
                alert(card.dataset.name);
                window.location.href = `/Send/${card.dataset.name}`
                
                //const request = await response.json();
                //const books = request.obj;
                //window.location.href = request.redirectUrl
                //// Перенаправляем на страницу категории с данными
                //redirectToCategoryPage(category, items);
                
            } catch (error) {
                console.error("Ошибка при загрузке данных:", error);
                alert("Произошла ошибка при загрузке данных");
            }
        });
    });

 