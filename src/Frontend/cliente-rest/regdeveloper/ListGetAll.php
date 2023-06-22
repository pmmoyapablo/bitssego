<?php
require __DIR__ . '/../vendor/autoload.php';
use GuzzleHttp\Client;
    //ARREGLOS
    $array_ProgramLanguages = new ArrayObject();
    $array_StatusIntegrations = new ArrayObject();
    $array_SystemOpers = new ArrayObject();
	$array_TaxMachines = new ArrayObject();
    //CLIENTES CONEXION
    $clientSgo = new Client([
        //'base_uri' => 'http://192.168.0.73:81', // servidor test // local hernan
		'base_uri' => 'http://localhost:81', // servidor local
        //'base_uri' => 'https://localhost:44330/api-access/Login',
        'timeout'  => 20.0,
        ]); 

   $optionsSgo = [
      'json' => [
                 'username' => 'sgove@tfhka.com',
                 'password' => 'Moneda32'
                ]
    ]; 

    //Obtengo el Token de Autorizacion
    $resSgo = $clientSgo->post('api-access/Login', $optionsSgo);


    if ($resSgo->getStatusCode() == '200'){
        //Convertir el resultado que viene en formato JSON a un array
        $jsonLoginArray = json_decode($resSgo->getBody(), true);

        if ($jsonLoginArray['authenticated']) {  //Obtenido el Token hago los GET en Sistema Operativos, Lenguajes de Programacion, Estatus y Otros Catalogos de relacion
            $headerSgo = array('Authorization' => 'Bearer ' . $jsonLoginArray['accessToken'],
                'Accept' => 'application/json');
            $options2 = [
                'headers' => $headerSgo
            ];

            $response_LP = $clientSgo->request('GET', 'api-utilities/ProgramLenguages', $options2);
            $response_SI = $clientSgo->request('GET', 'api-utilities/StatusIntegrations', $options2);
            $response_SO = $clientSgo->request('GET', 'api-utilities/SystemOpers', $options2);
            //api-products/Products
            $response_TM = $clientSgo->request('GET', 'api-products/Products', $options2);
            //RESPUESTA EXITOSA
            if ($response_LP->getStatusCode() == '200' && $response_SI->getStatusCode() == '200' && $response_SO->getStatusCode() == '200' && $response_TM->getStatusCode() == '200' ) { 
                $json_Array_PL = json_decode($response_LP->getBody(), true);
                $json_Array_SI = json_decode($response_SI->getBody(), true);
                $json_Array_SO = json_decode($response_SO->getBody(), true);
                $json_Array_TM = json_decode($response_TM->getBody(), true);
                //CONSTRUYE LOS ARREGLOS
                $array_ProgramLanguages = BuildArray($json_Array_PL);
                $array_StatusIntegrations = BuildArray($json_Array_SI);
                $array_SystemOpers = BuildArray($json_Array_SO);
                $array_TaxMachines = BuildArray($json_Array_TM);
            }
        }
    }

class Catalogo
{
    public $name;
    public $id;

    public function __construct($id, $name){
        $this->id = $id;
        $this->name = $name;
    }
}

function BuildArray($array){
    $i = 0;
    foreach ($json_Array_PL as $clave => $valor) {
        if($valor['visible']){
            $obj = new Catalogo($valor['id'], $valor['name']);
            $array[$i] = $obj;
            $i++;
        }
    }  
    return $array;  
}

?>