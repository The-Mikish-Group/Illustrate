document.addEventListener("DOMContentLoaded", function () {
    var images = document.querySelectorAll("img[data-src]");
    var imageContainer = document.getElementById("image-container");
    var currentRequest; // Declare currentRequest here

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
   
    // When the user scrolls down 20px from the top of the document, show the button
    window.onscroll = function () { scrollFunction() };

    function scrollFunction() {
        var mybutton = document.getElementById("top-button");
        if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
            mybutton.style.display = "block";
        } else {
            mybutton.style.display = "none";
        }
    }

    // When the user clicks on the button, scroll to the top of the document
    window.topFunction = function () { topFunction() };  

    function topFunction() {
        document.body.scrollTop = 0;
        document.documentElement.scrollTop = 0;
    }    
});

// Hide current menu selection


// Event listener for menu links
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

// Function to handle errors
function handleError(error, viewName) {
    console.error('Error loading view:', error);

    // Display a user-friendly error message
    imageContainer.innerHTML = '<div class="alert alert-danger" role="alert">Oops! Something went wrong. Redirecting to the home page...</div>';

    // Redirect to the home page after a delay (e.g., 3 seconds)
    setTimeout(function () {
        window.location.href = '/'; // Update the URL as needed
    }, 4000);
}