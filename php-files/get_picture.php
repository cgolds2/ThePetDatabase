<?php

// required headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
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
    echo -1;
    return -1;
}

$picture->pet_id = $pet_id;
$stmt = $picture->read_id();
$num = $stmt->rowCount();

// check if more than 0 record found
if ($num > 0) {
    // retrieve table contents
    $pic_arr = array();
    $pic_arr["pictures"] = array();

    while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
        // extract row
        extract($row);
        $pic = array(
            "pet_id" => $row['pet_id'],
            "data" => $row['data']
        );
        array_push($pic_arr["pictures"], $pic);
    }
    echo json_encode($pic_arr);
} else {
    echo "No pictures found for pet.";
}

?>
