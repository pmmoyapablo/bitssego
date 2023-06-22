<html>
<head>
	<title>Importador</title>
</head>
<body>
  <table align="center" border="0">   
      <tr>
        <td colspan="3"><h3 align="center">IMPORTAR CLIENTE DISTRIBUIDOR DIRECTO DESDE SAINT</h3></td>
	  </tr>
  </table>
<?php
require __DIR__ . '/../vendor/autoload.php';
use GuzzleHttp\Client;

$flag = false;
$idProvider = 1;

 if(!isset($_GET['rif']))
  {
     if(!isset($_POST["description1"])){
      echo "<div align='center'><font color='red'>No se ha recibido el argumento requerido para la consulta.</font></div><br>";
	  }
  }else
  {
	  if($_GET['rif'] != "")
	  {
  try {
	  $rifSaint = substr($_GET['rif'],0,1)."-".substr($_GET['rif'],1,8)."-".substr($_GET['rif'],9);  
	  //Busqueda en SAINT de The Factory HKA
	  $client = new Client([
	    //'base_uri' => 'http://localhost/ApiSaintStandar/api/Customers/'.$rifSaint,
		'base_uri' => 'http://192.168.0.73/ApiSaintStandar/api/Customers/'.$rifSaint,
	    'timeout'  => 20.0,
	  ]);
	   
	    $res = $client->request('GET'); 	
		if ($res->getStatusCode() == '200') //Verifico que me retorne 200 = OK
		{
			//Convertir el resultado que viene en formato JSON a un array
      $json2Array = json_decode($res->getBody(), true);
      
      //echo print_r($json2Array);
      
			if($json2Array != null)//if($json2Array['isSerializerData'])
			{ $flag = true; }
			//Ahora que esta la informacion en Array, podemos acceder a ella de forma sencilla
			//echo $json2Array['description'];
		}else
		{
		  //Busqueda en SAINT de Impresoras Fiscales 421
		  $client = new Client([
		   //'base_uri' => 'http://localhost/ApiSaintStandar/api/Customers421/'.$rifSaint,
	      'base_uri' => 'http://192.168.0.73/ApiSaintStandar/api/Customers421/'.$rifSaint,
	      'timeout'  => 20.0,
	       ]);
		   
		   $res = $client->request('GET');
		   if ($res->getStatusCode() == '200') //Verifico que me retorne 200 = OK
		   {		     
			 //Convertir el resultado que viene en formato JSON a un array
       $json2Array = json_decode($res->getBody(), true);
			 if($json2Array != null)//if($json2Array['isSerializerData'])
			{
			  $flag = true; 
			  $idProvider = 2;
			}
			 //Ahora que esta la informacion en Array, podemos acceder a ella de forma sencilla
			 //echo $json2Array['description'];
		   }
		}
	   } catch (Exception $e) {
          echo "<div align='center'><font color='red'>Error de Requerimiento HTTP : ".$e->getMessage()."</font></div><br>";
        }
     }else{
	   if(!isset($_POST["description1"])){
       echo "<div align='center'><font color='red'>El RIF no pude ser de valor Nulo.</font></div><br>";
	   }
     } 
  }
 
 if($flag)
 {
   $json2Array['ID3'] = str_replace("-", "" ,$json2Array['ID3']);
?>
  <table align="center" border="0">
  <form name="fsend" action="indexdemo.php" method="POST" >
    <INPUT type="hidden" name="description1" size="" value="<?php echo $json2Array['Descrip']; ?>" >
	<INPUT type="hidden" name="state1" size="" value="<?php echo $json2Array['DescripExt']; ?>" >
	<INPUT type="hidden" name="rif1" size="" value="<?php echo $json2Array['ID3']; ?>" >
	<INPUT type="hidden" name="country1" size="" value="Venezuela" >
	<INPUT type="hidden" name="nit1" size="" value="<?php echo $json2Array['NIT']; ?>" >
	<INPUT type="hidden" name="email1" size="" value="<?php echo "client".$json2Array['CodClie']."@tfhka.com"; ?>" >
	<INPUT type="hidden" name="represent1" size="" value="<?php echo $json2Array['Represent']; ?>" >
	<INPUT type="hidden" name="phone1" size="" value="<?php echo $json2Array['Telef']; ?>" >
	<INPUT type="hidden" name="nameSeller1" size="" value="Oficina Venta TFHKA" >
	<INPUT type="hidden" name="codeSeller1" size="" value="<?php echo $json2Array['CodVend']; ?>" >
	<INPUT type="hidden" name="phoneSeller1" size="" value="0212-2020811" >
	<INPUT type="hidden" name="address21" size="" value="<?php echo $json2Array['Direc2']; ?>" >
	<INPUT type="hidden" name="address11" size="" value="<?php echo $json2Array['Direc1']; ?>" >
	<INPUT type="hidden" name="city1" size="" value="<?php echo $json2Array['Observa']; ?>" >
	<INPUT type="hidden" name="code1" size="" value="<?php echo $json2Array['CodClie']; ?>" >
	<INPUT type="hidden" name="username" size="" value="<?php echo $_GET['username']; ?>" >
	<INPUT type="hidden" name="idProvider" size="" value="<?php echo $idProvider; ?>" >
      <tr>
        <td>Descripci&oacute;n:</td>
        <td><INPUT type="text" name="description" size="" value="<?php echo $json2Array['Descrip']; ?>" disabled ="true"></td>		
        <td>Estado:</td>
        <td><INPUT type="text" name="state" size="" disabled ="true" value="<?php echo $json2Array['DescripExt']; ?>"></td>
      </tr>
      <tr>
        <td>RIF:</td>
        <td><INPUT type="text" name="rif" size="" disabled ="true" value="<?php echo $json2Array['ID3']; ?>"></td>
        <td>Pa&iacute;s:</td>
        <td><INPUT type="text" name="country" size="" disabled ="true" value="Venezuela" ></td>
      </tr>
      <tr>
        <td>NIT:</td>
        <td><INPUT type="text" name="nit" size="" disabled ="true" value="<?php echo $json2Array['NIT']; ?>"></td>
        <td>Email:</td>
        <td><INPUT type="text" name="email" size="" disabled ="true" value="<?php echo "client".$json2Array['CodClie']."@tfhka.com"; ?>" ></td>
      </tr>
      <tr>
        <td>Representante:</td>
        <td><INPUT type="text" name="represent" size="" disabled ="true" value="<?php echo $json2Array['Represent']; ?>"></td>
        <td>Tel&eacute;fono:</td>
        <td><INPUT type="text" name="phone" size="" disabled ="true" value="<?php echo $json2Array['Telef']; ?>"></td>
      </tr>
      <tr>
        <td>Direcci&oacute;n 1:</td>
        <td><INPUT type="text" name="address" size="" disabled ="true" value="<?php echo $json2Array['Direc1']; ?>"></td>
        <td>Vendedor:</td>
        <td><INPUT type="text" name="nameSeller" size="" disabled ="true" value="Oficina Venta TFHKA"></td>
      </tr>
      <tr>
        <td>Direcci&oacute;n 2:</td>
        <td><INPUT type="text" name="address2" size="" disabled ="true" value="<?php echo $json2Array['Direc2']; ?>"></td>
        <td>Ciudad:</td>
        <td><INPUT type="text" name="city" size="" disabled ="true" value="<?php echo $json2Array['Observa']; ?>"></td>
      </tr>
      <tr>
	    <td>Password:</td>
        <td colspan="4"><INPUT type="password" name="password" size=""></td>
      </tr>
      <tr>
        <td colspan="4" align="center"><INPUT type="submit" value="Enviar Datos a SGOTFHKA" ></td>
      </tr>	  
	  </form>
  </table>
<?php
   
   }else
   {
      if(!isset($_POST["description1"])){
      echo "<div align='center'><font color='red'>No se encontraron datos para este RIF. Verifique tu correcta denominaci&oacute;n.</font></div><br>";
	  }
   }
 
  if(isset($_POST["description1"])){
  try{
		$client = new Client([
			'base_uri' => 'http://sgotfhka.thefactory.com.ve',
		    'timeout'  => 40.0,
			]);
			// =============================================
			//Hago la llamada al servicio rest, loguear y obtener el Token de Autorization
			   $options = [
                  'json' => [
                             'username' => $_POST["username"],
					         'password' => $_POST["password"]
                            ]
				  //,'verify' => false			
                ]; 
	    
			$res = $client->post('ApisSgo/api-access/Login', $options);
			
			if ($res->getStatusCode() == '200') //Verifico que me retorne 200 = OK
			{  			 
			         //Convertir el resultado que viene en formato JSON a un array
			        $jsonLoginArray = json_decode($res->getBody(), true);

			        if($jsonLoginArray['authenticated'])
					{  //Obtenido el Token hago los post en los recursos /Distributors y /Users
					  $header = array('Authorization'=>'Bearer '.$jsonLoginArray['accessToken']);
					  $options = [
                        'json' => [
								  'id' => 0,
                                  'idSA' => $_POST["code1"],
                                  'rif' => $_POST["rif1"],
                                  'description' => $_POST["description1"],
                                  'represent' => $_POST["represent1"],
                                  'address' => $_POST["address11"],
                                  'country' => $_POST["country1"],
                                  'state' => $_POST["state1"],
                                  'city' => $_POST["city1"],
                                  'phone' => $_POST["phone1"],
                                  'email' => $_POST["email1"],
                                  'nit' => $_POST["nit1"],
                                  'codeZone' => '',
                                  'nameSeller' => $_POST["nameSeller1"],
                                  'rifSeller' => $_POST["codeSeller1"],
                                  'phoneSeller' => $_POST["phoneSeller1"],
                                  'typeAgreement' => '',
                                  'enable' => 1
                            ],
						'headers' => $header
                       ]; 
					   
					   //Hago el POST al recurso Distribuidor
					   $res = $client->post('ApisSgo/api-clients/Distributors', $options);

					   if ($res->getStatusCode() == '201') //Verifico que me retorne 201 = Created
					   {
					     $jsonDistArray = json_decode($res->getBody(), true);
				         $idDistributor = $jsonDistArray['id'];
					     //POST en Relacion Distribuidor-Provider
						 $options = [
                         'json' => [
								  'id' => $_POST["idProvider"],                                 
                                  'rif' => $_POST["rif1"],
                                  'description' => $_POST["description1"],
                                  'address' => $_POST["address11"],
                                  'phone' => $_POST["phone1"],
                                  'email' => $_POST["email1"],
                                  'image' => 0
                            ],
						 'headers' => $header
                        ]; 
					   
					     $res = $client->post('ApisSgo/api-clients/Distributors/'.$idDistributor.'/Providers', $options);
						 //POST en User
						 $options1 = [
                         'json' => [
								  'id' => 0,                                 
                                  'rolId' => 9,
                                  'username' => $_POST["email1"],
                                  'password' => 'Passwo12',
                                  'enable' => 1
                            ],
						 'headers' => $header
                        ]; 
                 
						$res = $client->post('ApisSgo/api-access/Users', $options1);
						if ($res->getStatusCode() == '201') //Verifico que me retorne 201 = Created
						{
						   //POST en Relacion Distribuidor-Users
						   $jsonUserArray = json_decode($res->getBody(), true);
						   $idUser = $jsonUserArray['id'];
						    $options2 = [
						    'headers' => $header
                           ]; 
						   $res = $client->post('ApisSgo/api-clients/Distributors/'.$idDistributor.'/'.$idUser, $options2);
						}
						
						 echo "<div align='center'><font color='green'>Datos Importados Exitosamente.</font></div><br>";
					       
					   }else
					   {
					     echo "<div align='center'><font color='red'>Error ".$res->getStatusCode().". No se pudo importar los datos del distribuidor al SGO.</font></div><br>";
					   }
					}
					else
					{
					    echo "<div align='center'><font color='red'>Error de Autenticaci&oacute;n. Password incorrecto.</font></div><br>";
					}
			}
			
   } catch (Exception $e) {
          echo "<div align='center'><font color='red'>Error de Requerimiento HTTP : ".$e->getMessage()."</font></div><br>";
   }
  }
?>
  <table align="center" border="0">
      <tr>
        <td colspan="4" align="center"><INPUT type="button" value="Salir" onclick = "javascript:window.close()" ></td>
      </tr>
   </table>
</body>
</html>