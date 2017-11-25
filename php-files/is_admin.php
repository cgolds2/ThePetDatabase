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

$user_id_param = filter_input(INPUT_GET, 'uid', FILTER_SANITIZE_STRING);
$shelter_id_param = filter_input(INPUT_GET, 'sid', FILTER_SANITIZE_STRING);
if ($user_id_param != null && $shelter_id_param != null) {
    $shelter->id = $shelter_id_param;
    $shelter->admin_id = $user_id_param;
    $stmt = $shelter->is_admin();
} else {
    echo json_encode(
            array("error" => "uid (user_id) or sid (shelter_id) not given.")
    );
    return -1;
}
$num = $stmt->rowCount();

// check if more than 0 record found
if ($num > 0) {
    echo "true";
    return 1;
} else {
    echo "false";
    return -1;
}

?>
