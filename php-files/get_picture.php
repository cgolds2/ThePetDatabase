<?php

// required headers
header("Access-Control-Allow-Origin: *");
//header("Content-Type: multipart/form-data");
header("Access-Control-Allow-Methods: GET");
header("Access-Control-Max-Age: 3600");
header("Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With"); 

// include required files
include_once 'db.php';
include_once 'picture.php';

// create new database connection
$database = new Db();
$conn = $database->getConnection();

$picture = new Picture($conn);

$pet_id = filter_input(INPUT_GET, 'id', FILTER_SANITIZE_STRING);

if ($pet_id == null) {
    echo '{';
    echo '"error": "No Shelter ID specified to update."';
    echo '}';
    return -1;
}

$picture->pet_id = $pet_id;
$stmt = $picture->read_all();
$num = $stmt->rowCount();

// check if more than 0 record found
if ($num > 0) {
    // retrieve table contents
    while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
        // extract row
        extract($row);
        echo $row['data'];
    }
} else {
    echo "No pictures found for pet.";
}

?>
