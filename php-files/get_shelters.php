<?php

// required headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");

// include required files
include_once 'db.php';
include_once 'shelter.php';

// create new database connection
$database = new Db();
$conn = $database->getConnection();

$shelter = new Shelter($conn);

$id_param = filter_input(INPUT_GET, 'id', FILTER_SANITIZE_STRING);
if ($id_param != null) {
    $shelter->id = $id_param;
    $stmt = $shelter->read_id();
} else {
    $stmt = $shelter->read_all();
}
$num = $stmt->rowCount();

// check if more than 0 record found
if ($num > 0) {
    // department array
    $shelter_arr = array();
    $shelter_arr["shelters"] = array();

    // retrieve table contents
    while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
        // extract row
        extract($row);
        $shelters = array(
            "id" => $row['id'],
            "name" => $row['name'],
            "address" => $row['address'],
            "website" => $row['website'],
            "phone_number" => $row['phone_number'],
            "admin_id" => $row['admin_id']
        );
        array_push($shelter_arr["shelters"], $shelters);
    }
    echo json_encode($shelter_arr);
} else {
    echo json_encode(
            array("error" => "No shelters found.")
    );
}

?>
