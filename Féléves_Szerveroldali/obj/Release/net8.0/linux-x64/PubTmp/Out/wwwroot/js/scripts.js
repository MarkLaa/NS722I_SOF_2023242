

// Function to fill the table body
function fillTableBody(data) {
    const tableBody = document.getElementById('tablebody');

    // Clear existing table body content
    tableBody.innerHTML = '';

    // Loop through data and create table rows
    data.forEach(item => {
        const row = document.createElement('tr');

        const cellId = document.createElement('td');
        cellId.textContent = item.id;
        row.appendChild(cellId);

        const cellName = document.createElement('td');
        cellName.textContent = item.name;
        row.appendChild(cellName);

        const cellEmail = document.createElement('td');
        cellEmail.textContent = item.feladat;
        row.appendChild(cellEmail);

        item.csapattagok.forEach(part => {
            const cellPart = document.createElement('td');
            cellPart.textContent = part;
            row.appendChild(cellPart);
        });

        tableBody.appendChild(row);
    });
}

document.addEventListener('DOMContentLoaded', () => {
    $.ajax({
        url: '/Feladat/GetData', // Replace with your API endpoint
        method: 'GET',
        success: function (response) {
            fillTableBody(response);
        },
        error: function (error) {
            console.error('Error fetching data:', error);
        }
    });
});

// Call the function to fill the table on page load
//document.addEventListener('DOMContentLoaded', () => {
//    fillTableBody(data);
//});