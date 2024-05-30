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


    if (/^[0-9]{15}$/.test(nationalID)){
        errorDiv.style.display = 'block';
        errorMsg.textContent = "Please Enter Valid National ID";
        return false;
    }

    if (/^[0-9]{11}$/.test(phoneNumber)) {
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

    // If all validations pass, return true to submit the form
    return true;
}


document.getElementById('bookingForm').addEventListener('submit', async function (event) {
    if (!validateForm()) {
        event.preventDefault();
        return;
    }
    const form = event.target;
    const formData = new FormData(form);

    // Get selected room numbers
    const roomNumbers = [];
    form.querySelectorAll('input[name="RoomNumber"]:checked').forEach(checkbox => {
        roomNumbers.push(checkbox.value);
    });
    console.log(roomNumbers)
    // Prepare data to be sent
    const data = {
        CustomerName: formData.get('CustomerName'),
        NationalID: formData.get('NationalID'),
        PhoneNumber: formData.get('PhoneNumber'),
        CheckInDate: formData.get('CheckInDate'),
        CheckOutDate: formData.get('CheckOutDate'),
        TotalRooms: formData.get('TotalRooms'),
        RoomNumber: roomNumbers,
        BranchName: formData.get('BranchName')
    };

    try {
        const response = await fetch('/booking/create', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (response.ok) {
            const result = await response.json();
            Swal.fire({
                title: 'Success',
                text: 'Booking created successfully!',
                icon: 'success',
                confirmButtonText: 'OK'
            });
        } else {
            const errorData = await response.json();
            document.getElementById('errordiv').innerText = errorData.message || 'An error occurred';
            Swal.fire({
                title: 'Error',
                text: errorData.message || 'An error occurred',
                icon: 'error',
                confirmButtonText: 'OK'
            });
        }
    } catch (error) {
        document.getElementById('errordiv').innerText = 'An error occurred';
        Swal.fire({
            title: 'Error',
            text: 'An error occurred',
            icon: 'error',
            confirmButtonText: 'OK'
        });
    }
});
