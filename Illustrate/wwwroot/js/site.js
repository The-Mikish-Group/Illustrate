// Lazy load images
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

function hideCurrentMenuSelection(viewName) {
    if (viewName) {
        var element = document.getElementById(viewName);
        if (element) {
            element.style.display = "none";
        }
    }
}

document.addEventListener("DOMContentLoaded", function () {
    var viewName = getParameterByName("viewName");
    hideCurrentMenuSelection(viewName);

    // When the user scrolls down 20px from the top of the document, show the button
    window.onscroll = function () { scrollFunction() };
    window.topFunction = function () {topFunction() };
    function scrollFunction() {
        var mybutton = document.getElementById("my-button");
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


    function getParameterByName(name) {
        var url = window.location.href;
        name = name.replace(/[\[\]]/g, "\\$&");
        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
            results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, " "));
    }
});

