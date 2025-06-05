// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const cards = document.querySelectorAll('.card');
    cards.forEach(card => {
        card.addEventListener('click', async function() {
            const category = this.querySelector('h3').textContent.toLowerCase(); // "фильмы", "книги" или "музыка"
            
            try {
                // Отправляем GET запрос с категорией в query параметре
                //const response = await fetch(`/api/items?category=${encodeURIComponent(category)}`);
                const response = await fetch(`/Send/books?category=${encodeURIComponent(category)}`);
                if (!response.ok) {
                    throw new Error(`Ошибка HTTP: ${response.status}`);
                }
                
                const items = await response.json();
                
                // Перенаправляем на страницу категории с данными
                redirectToCategoryPage(category, items);
                
            } catch (error) {
                console.error("Ошибка при загрузке данных:", error);
                alert("Произошла ошибка при загрузке данных");
            }
        });
    });

    // Функция для перенаправления и отображения данных
    function redirectToCategoryPage(category, items) {
        // Сохраняем данные в sessionStorage для использования на новой странице
        sessionStorage.setItem(category + '_items', JSON.stringify(items));
        
        // Перенаправляем на страницу категории
        window.location.href = `/category.html?category=${encodeURIComponent(category)}`;
    }

    // Если мы на странице категории, загружаем и отображаем данные
    if (window.location.pathname.includes('category.html')) {
        loadCategoryItems();
    }


// Функция для загрузки и отображения элементов категории
function loadCategoryItems() {
    const urlParams = new URLSearchParams(window.location.search);
    const category = urlParams.get('category');
    
    if (!category) return;
    
    const storedItems = sessionStorage.getItem(category + '_items');
    let items = [];
    
    if (storedItems) {
        items = JSON.parse(storedItems);
        displayItems(items);
    } else {
        // Если данных нет в sessionStorage, загружаем с сервера
        fetch(`/api/items?category=${encodeURIComponent(category)}`)
            .then(response => response.json())
            .then(items => displayItems(items))
            .catch(error => console.error("Ошибка при загрузке данных:", error));
    }
}

// Функция для отображения элементов на странице
function displayItems(items) {
    const container = document.querySelector('.category-container') || document.createElement('div');
    container.className = 'category-container';
    container.innerHTML = '';
    
    items.forEach(item => {
        const card = document.createElement('div');
        card.className = 'item-card';
        card.innerHTML = `
            <h3>${item.title}</h3>
            <p>${item.description || ''}</p>
            ${item.image ? `<img src="${item.image}" alt="${item.title}">` : ''}
            <div class="rating">Рейтинг: ${item.rating || 'нет'}</div>
        `;
        container.appendChild(card);
    });
    
    if (!document.querySelector('.category-container')) {
        document.body.appendChild(container);
    }
}