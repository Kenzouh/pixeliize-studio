// Storing this in a variable because we will use this in multiple occasions.
const toggleButton = document.getElementById('toggle-btn');
const sidebar = document.getElementById('sidebar');



// Sidebar Icon Rotation and Opening the sidebar.
function toggleSidebar() {
    const icon = document.getElementById('menu-icon');
    const sidebar = document.getElementById('sidebar');

    icon.classList.toggle('rotate');   // Rotate the icon
    sidebar.classList.toggle('close'); // Close the sidebar
}

// Sidebar Dropdown Menu Toggle
function toggleSubMenu(button) {
    const submenu = button.nextElementSibling;
    submenu.classList.toggle('show');

    const arrowIcon = button.querySelector('.arrow-icon');
    if (arrowIcon) arrowIcon.classList.toggle('rotate');
}


function toggleSubMenu(button) {
    const submenu = button.nextElementSibling;
    submenu.classList.toggle('show');

    const arrowIcon = button.querySelector('.arrow-icon');
    if (arrowIcon) arrowIcon.classList.toggle('rotate-icon');

    // Open sidebar if it's closed when dropdown is clicked
    if (sidebar.classList.contains('close')) {
        sidebar.classList.remove('close');
        toggleButton.querySelector('svg')?.classList.remove('rotate');
    }
}



// Data Privacy Policy Popup (Sign Up Page)
function showPrivacyModal() {
    document.getElementById('privacyModal').classList.remove('hidden');
}

function closePrivacyPopup() {
    document.getElementById('privacyModal').classList.add('hidden');
}

function submitForm() {
    document.getElementById('signupForm').submit();
}


// ========== Profile Profile Page Modal ========== 

// Open
function showProfileModal() {
    document.getElementById('profileModal').classList.remove('hidden');
}

// Close
function closeProfileModal() {
    document.getElementById('profileModal').classList.add('hidden');
}

// ========== Pet Listing Modal ========== 

// (Admin Page)
function showPetUploadModal() {
    document.getElementById('petUploadModal').classList.remove('hidden');
}

function closePetUploadModal() {
    document.getElementById('petUploadModal').classList.add('hidden');
}