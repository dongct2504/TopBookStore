$(document).ready(() => {
    // Get the input element for the image
    const imageInput = $('#uploadBox');

    // Add an event listener for when the user selects a file
    imageInput.on('change', (event) => {
        const file = event.target.files[0];
        const image = new Image();
        const reader = new FileReader();

        // return error if the image is > 1M
        if (file.size > 1024 * 1024) {
            Swal.fire({
                icon: "error",
                title: "Lỗi!",
                text: "Vui lòng nhập ảnh có kích thước nhỏ hơn 1M.",
            })
            imageInput.val(null);
            return;
        }

        // Load the selected image file
        reader.onload = (event) => {
            image.onload = () => {
                const imageHeight = image.height;
                const imageWidth = image.width;

                const ratio = imageHeight / imageWidth;

                if (ratio < 1.2 || ratio > 1.8) {
                    Swal.fire({
                        icon: "error",
                        title: "Lỗi!!!",
                        text: "Vui lòng nhập ảnh có tỉ lệ chiều cao/chiều rộng lớn" +
                            " hơn 1.2 và nhỏ hơn 1.8.",
                    })
                    imageInput.val(null);
                } else {
                    $('#previewImage').attr('src', event.target.result);
                    $('#previewImage').show();
                }
            };

            image.src = event.target.result;
        };

        // Read the selected image file as a data URL
        reader.readAsDataURL(file);
    });
});