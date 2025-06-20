// Storing this in a variable because we will use this in multiple occasions.
const toggleButton = document.getElementById('toggle-btn');
const sidebar = document.getElementById('sidebar');

function toggleSidebar() {
    sidebar.classList.toggle('close');
    toggleButton.classList.toggle('rotate');
}



function toggleSubMenu(button) {
    button.nextElementSibling.classList.toggle('show');

    // Rotates the SVG arrows.
    button.classList.toggle('rotate');

    /* Opens the sidebar if the drpodown buttons got clicked */
    if (sidebar.classList.contains('close')) {
        sidebar.classList.toggle('close');

        /* Rotates the toggle icon SVG if the buttons of the sidebar icons got clicked */
        toggleButton.classList.toggle('rotate');
    }
}