﻿// Lazy load images
document.addEventListener("DOMContentLoaded", function () {
    var images = document.querySelectorAll("img[data-src]");
    var imageContainer = document.getElementById("image-container");

    var observer = new IntersectionObserver(
        function (entries, observer) {
            entries.forEach(function (entry) {
                if (entry.isIntersecting) {
                    var img = entry.target;
                    img.src = img.getAttribute("data-src");
                    observer.unobserve(img);
                }
            });
        }
    );

    images.forEach(function (img) {
        observer.observe(img);
    });

    var checkLoadingCompletion = function () {
        if (Array.from(images).every(img => img.complete)) {
            imageContainer.style.display = "flex";
        } else {
            setTimeout(checkLoadingCompletion, 100);
        }
    };

    checkLoadingCompletion();

    // Top button stuff
    // When the user scrolls down 20px from the top of the document, show the button
    window.onscroll = function () { scrollFunction() };
    window.topFunction = function () { topFunction() };
    function scrollFunction() {
        var mybutton = document.getElementById("top-button");
        if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
            mybutton.style.display = "block";
        } else {
            mybutton.style.display = "none";
        }
    }

    // When the user clicks on the button, scroll to the top of the document
    function topFunction() {
        document.body.scrollTop = 0;
        document.documentElement.scrollTop = 0;
    }

});

// Hide current menu selection
function hideCurrentMenuSelection(viewName) {
    var elements = document.querySelectorAll('.menu-item');
    elements.forEach(function (element) {
        if (element.getAttribute('data-viewName') === viewName) {
            element.style.display = 'none';
        } else {
            element.style.display = '';
        }
    });
}

// Top of screen button
document.addEventListener("DOMContentLoaded", function () {

     
});

