<main>
    <div class="row">
        <div class="col-md-6">
            <h2>Send JSON Data to API</h2>

            <form id="apiForm">
                <label for="jsonInput">Enter JSON:</label>
                <textarea id="jsonInput" name="jsonInput" class="form-control" rows="5"
                          placeholder='{"key1": "value1", "key2": "value2", "key3": "value3"}'
                          required></textarea>
                <small class="text-danger" id="jsonError"></small>

                <button type="submit" class="btn btn-primary mt-3">Send API Request</button>
            </form>

            <div id="responseMessage" class="mt-4"></div>
        </div>
    </div>
</main>

<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
<script>
    $(document).ready(function () {
        $("#apiForm").submit(function (event) {
            event.preventDefault(); // Prevent default form submission

            var jsonInput = $("#jsonInput").val().trim();
            var jsonError = $("#jsonError");
            jsonError.text(""); // Clear previous errors

            try {
                // Parse JSON input
                var requestData = JSON.parse(jsonInput);

                // Validate that there are exactly 3 key-value pairs
                var keys = Object.keys(requestData);
                if (keys.length !== 3) {
                    throw new Error("JSON must contain exactly 3 key-value pairs.");
                }

                // Send AJAX request
                $.ajax({
                    url: "/api/values",
                    type: "POST",
                    contentType: "application/json",
                    data: JSON.stringify(requestData),
                    success: function (response) {
                        // Build dynamic response UI
                        let responseHtml = "<div class='card border-success'>" +
                            "<div class='card-header bg-success text-white'>API Response</div>" +
                            "<div class='card-body'>";

                        // Loop through response fields dynamically
                        $.each(response.receivedData, function (key, value) {
                            responseHtml += `<p><strong>${key}:</strong> ${value}</p>`;
                        });

                        responseHtml += "</div></div>";
                        $("#responseMessage").html(responseHtml);
                    },
                    error: function (xhr) {
                        var errorMsg = xhr.responseJSON ? xhr.responseJSON.error : "Unknown error occurred.";
                        $("#responseMessage").html(
                            `<div class='alert alert-danger'><strong>Error:</strong> ${errorMsg}</div>`
                        );
                    }
                });
            } catch (error) {
                jsonError.text(error.message); // Show JSON error
            }
        });
    });
</script>
