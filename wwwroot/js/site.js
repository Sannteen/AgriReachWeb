// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


let bagCount = 0;

function increaseQty(btn) {
    const input = btn.previousElementSibling;
    input.value = parseInt(input.value) + 1;
}

function decreaseQty(btn) {
    const input = btn.nextElementSibling;
    if (parseInt(input.value) > 1) {
        input.value = parseInt(input.value) - 1;
    }
}

function addToBag(productName, btn) {
    const qty = btn.parentElement.querySelector('.qty-input').value;
    bagCount += parseInt(qty);
    document.getElementById("bagCount").innerText = bagCount;
}

function filterProducts(text) {
    text = text.toLowerCase();
    document.querySelectorAll(".product-card").forEach(card => {
        card.style.display = card.dataset.name.toLowerCase().includes(text)
            ? "block"
            : "none";
    });
}

