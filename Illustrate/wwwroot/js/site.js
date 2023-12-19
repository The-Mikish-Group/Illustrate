document.addEventListener("DOMContentLoaded", function () {
    var currentRequest;

    // Lazy load images
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

    // 'Top of screen' button on long pages
    var topButton = document.getElementById("top-button");

    window.onscroll = function () {
        if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
            topButton.style.display = "block";
        } else {
            topButton.style.display = "none";
        }
    };

    window.topFunction = function () {
        document.body.scrollTop = 0;
        document.documentElement.scrollTop = 0;
    };

    document.querySelectorAll('.menu-link').forEach(function (link) {
        link.addEventListener('click', function () {
            var viewName = link.dataset.viewName;

            if (currentRequest) {
                currentRequest.abort();
            }

            // Display a loading spinner or any other visual indication
            imageContainer.innerHTML = '<div class="spinner-border" role="status"><span class="visually-hidden">Loading...</span></div>';

            // Make a new request for the selected view with a delay
            setTimeout(function () {
                fetchData(viewName);
            }, 4000); // Adjust the delay time (in milliseconds) as needed
        });
    });

    // Function to fetch data
    function fetchData(viewName) {
        currentRequest = fetch(`/home/images?viewName=${viewName}`)
            .then(response => response.text())
            .then(html => updateUI(html, viewName))
            .catch(error => handleError(error, viewName));
    }

    // Function to update UI
    function updateUI(html, viewName) {
        imageContainer.innerHTML = html;

        // Trigger lazy loading for new images (if applicable)
        var newImages = document.querySelectorAll("#image-container img[data-src]");
        newImages.forEach(function (img) {
            observer.observe(img);
        });

        checkLoadingCompletion();

        // Hide the current menu selection
        hideCurrentMenuSelection(viewName);
    }

    // Function to handle errors
    function handleError(error, viewName) {
        console.error('Error loading view:', error);

        // Display a user-friendly error message
        imageContainer.innerHTML = '<div class="alert alert-danger" role="alert">Oops! Something went wrong. Please try again later.</div>';

        // You might want to hide the current menu selection even if there's an error
        hideCurrentMenuSelection(viewName);
    }

    // Function to hide current menu selection
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
});
