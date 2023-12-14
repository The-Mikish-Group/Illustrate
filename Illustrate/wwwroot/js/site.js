// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function loadImages() {
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
    });
}