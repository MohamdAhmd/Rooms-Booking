function validateForm() {
    // Get form inputs
    let customerName = document.getElementById('customerName').value;
    let nationalID = document.getElementById('nationalID').value;
    let phoneNumber = document.getElementById('phoneNumber').value;
    let checkInDate = document.getElementById('checkInDate').value;
    let checkOutDate = document.getElementById('checkOutDate').value;
    let totalRooms = document.getElementById('totalRooms').value;
    let branchName = document.getElementById('branchName').value;
    let roomNumbers = document.getElementsByName('RoomNumbers');
    let errorDiv = document.getElementById("errordiv")
    let errorMsg = document.getElementsByClassName('error-message')[0];

    // Validate each input field
    if (!customerName || !/^[A-Za-z]{8,}$/.test(customerName)) {
        errorDiv.style.display = 'block';
        errorMsg.textContent = "Please Enter Valid Named";
        return false;
    }


    if (/^[0-9]{6,20}$/.test(nationalID)){
        errorDiv.style.display = 'block';
        errorMsg.textContent = "Please Enter Valid National ID";
        return false;
    }

    if (/^[0-9{11}$]/.test(phoneNumber)) {
        errorDiv.style.display = 'block';
        errorMsg.textContent = "Please Enter Valid Phone Number";
        return false;
    }

    if (checkInDate === '') {
        errorDiv.style.display = 'block';
        errorMsg.textContent = "Please Enter Check In Date";
        return false;
    }

    if (checkOutDate === '') {
        errorDiv.style.display = 'block';
        errorMsg.textContent = "Please Enter Check Out Date";
        return false;
    }

    if (totalRooms === '' || isNaN(totalRooms) || totalRooms <= 0) {
        errorDiv.style.display = 'block';
        errorMsg.textContent = "Please Enter Total Rooms";
        return false;
    }

    if (branchName === '') {
        errorDiv.style.display = 'block';
        errorMsg.textContent = "Please Select Branch Name";
        return false;
    }

    let selectedRoomNumbers = Array.from(roomNumbers).filter(room => room.checked).length;
    if (selectedRoomNumbers === 0) {
        errorDiv.style.display = 'block';
        errorMsg.textContent = "Please Select Room Number";
        return false;
    }

    // If all validations pass, return true to submit the form
    return true;
}

document.getElementById('bookingForm').addEventListener('submit', function (event) {
    // Prevent the form from submitting the traditional way if validation fails
    if (!validateForm()) {
        event.preventDefault();
        return; // Exit the function if validation fails
    }

    // If validation passes, submit the form data
    let formData = new FormData(this);
    fetch('/Booking/Create', {
        method: 'POST',
        body: formData
    })
        .then(response => response.json())
        .then(data => {
            if (data.message) {
                alert(data.message); // Show success message
            }
        })
        .catch(error => console.error('Error:', error));
});
