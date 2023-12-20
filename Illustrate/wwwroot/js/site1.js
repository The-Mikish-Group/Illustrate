document.addEventListener("DOMContentLoaded", function () {
    var images = document.querySelectorAll("img[data-src]");
    var imageContainer = document.getElementById("image-container");
    var currentRequest;
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

    window.onscroll = function () { scrollFunction() };

    function scrollFunction() {
        var mybutton = document.getElementById("top-button");
        if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
            mybutton.style.display = "block";
        } else {
            mybutton.style.display = "none";
        }
    }

    window.topFunction = function () { topFunction() };

    function topFunction() {
        document.body.scrollTop = 0;
        document.documentElement.scrollTop = 0;
    }
});

document.querySelectorAll('.menu-link').forEach(function (link) {
    link.addEventListener('click', function () {
        var viewName = link.dataset.viewName;

        if (currentRequest) {
            currentRequest.abort();
        }

        imageContainer.innerHTML = '<div class="spinner-border" role="status"><span class="visually-hidden">Loading...</span></div>';

        fetchData(viewName);
    });
});

var baseUrl = '/home/images';

function fetchData(viewName) {
    if (viewName) {
        currentRequest = fetch(`${baseUrl}?viewName=${viewName}`)
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }
                return response.text();
            })
            .then(html => updateUI(html, viewName))  // Assuming you have an updateUI function
            .catch(error => handleError(error, viewName));
    } else {
        window.location.href = '/home/Images?viewName=flowers'; // Adjust the URL as needed
    }
}

function updateUI(html, viewName) {
    var newImages = document.querySelectorAll("#image-container img[data-src]");
    newImages.forEach(function (img) {
        observer.observe(img);
    });

    checkLoadingCompletion();
    hideCurrentMenuSelection(viewName);
}

function handleError(error, viewName) {
    console.error('Error loading view:', error);

    imageContainer.innerHTML = '<div class="alert alert-danger" role="alert">Oops! Something went wrong. Redirecting to the home page...</div>';

    setTimeout(function () {
        window.location.href = '/'; // Update the URL as needed
    }, 4000);
}
