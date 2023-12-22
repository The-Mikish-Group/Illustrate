// Lazy load Gallery
document.addEventListener("DOMContentLoaded", function () {
    var images = document.querySelectorAll("img[data-src]");
    var imagesContainer = document.getElementById("images-container");
    
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
            imagesContainer.style.display = "flex";
        } else {
            setTimeout(checkLoadingCompletion, 100);
        }
    };

    checkLoadingCompletion();

    // Top button stuff
    window.onscroll = function () { scrollFunction() };

    function scrollFunction() {

        var topbutton = document.getElementById("top-button");

        // When the user scrolls down 20px from the top of the document, show the button
        if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
            topbutton.style.display = "block";
        } else {
            topbutton.style.display = "none";
        }
    }

    // When the user clicks on the button, scroll to the top of the document
    window.topFunction = function () { topFunction() };  
    
    function topFunction() {
        document.body.scrollTop = 0;
        document.documentElement.scrollTop = 0;
    }
});


