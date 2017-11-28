<?php

// required headers
header("Access-Control-Allow-Origin: *");
// header("Content-Type: multipart/form-data");
header("Access-Control-Allow-Methods: POST");
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

function get_ext($imagetype)
 {
   if(empty($imagetype)) return false;
   switch($imagetype)
   {
       case 'image/gif': return '.gif';
       case 'image/jpeg': return '.jpg';
       case 'image/png': return '.png';
       default: return false;
   }
 }

$pic = file_get_contents('php://input');
	 
if (!empty($_FILES["picture"]["name"])) {

	$temp_name=$_FILES["picture"]["tmp_name"];
	$imgtype=$_FILES["picture"]["type"];
	$ext= get_ext($imgtype);
	$imagename=date("d-m-Y")."-".time().$ext;
	$target_path = "images/".$imagename;
	

    if(move_uploaded_file($temp_name, $target_path)) {

        $picture->pet_id = $pet_id;
        $picture->data = $target_path;

        if ($picture->create()) {
            echo 1;
            return 1;
        } else {
            echo -1;
            return -1;
        }
        
    } else {
        echo -1;
        return -1;
    } 

} else {
    echo -1;
    return -1;
}

?>
