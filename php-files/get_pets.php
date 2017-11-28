<?php

// required headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");

// include required files
include_once 'db.php';
include_once 'petdata.php';

// create new database connection
$database = new Db();
$conn = $database->getConnection();

$pet_data = new PetData($conn);

$shelter_id_param = filter_input(INPUT_GET, 'id', FILTER_SANITIZE_STRING);

if ($shelter_id_param != null) {
    $pet_data->shelter_id = $shelter_id_param;
    $stmt = $pet_data->read_id();
} else {
    $stmt = $pet_data->read_all();
}
$num = $stmt->rowCount();


// check if more than 0 record found
if ($num > 0) {
    // department array
    $pet_arr = array();
    $pet_arr["pets"] = array();

    // retrieve table contents
    while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
        // extract row
        extract($row);
        $pet = array(
            "id" => $row['id'],
            "age" => $row['age'],
            "name" => $row['name'],
            "notes" => $row['notes'],
            "breed" => $row['breed'],
            "animal_type" => $row['animal_type'],
            "weight" => $row['weight'],
            "shelter_id" => $row['shelter_id'],
            "profile_picture" => $row['profile_picture'],
            "size" => $row['size'],
            "chip_id" => $row['chip_id']
        );
        array_push($pet_arr["pets"], $pet);
    }
    echo json_encode($pet_arr);
} else {
    echo json_encode(
            array("error" => "No pets found.")
    );
}

?>
