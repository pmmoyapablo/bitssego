<head>
<meta http-equiv="content-type" content="text/html; charset=UTF-8" >
<title> Sistema de Validaci&oacuten</title>
<link href='mefamdd.css' rel='stylesheet' type='text/css'>
</head>
<body align='center'>

<style>
 .round {
				 background-color: #fff;
				 width: auto;
				 height: auto;
				 margin: 0 auto 5px auto;
				 padding: 2px;
				 border: 1px solid #ccc;
				 -moz-border-radius: 4px;
				 -webkit-border-radius: 4px;
				 border-radius: 4px;
				 behavior: url(border-radius.htc);
			}

</style>

<!-- <h1 align='center'>Validaci&oacuten SENIAT</h1> -->

<?php
require __DIR__ . '/../vendor/autoload.php';
use GuzzleHttp\Client;

  $rif1 = @$_GET["p_rif"];
  $rif = @$_POST["p_rif"];
  $codigo = @$_POST["codigo"];
  $url = "http://contribuyente.seniat.gob.ve/BuscaRif/BuscaRif.jsp";
  
  if(!$_COOKIE)
  {
	$fp = fopen("cookie.txt", "r");
	while (!feof($fp)){
		$linea = fgets($fp);
		list($name, $value) = explode('|', $linea, 2);	
		$_COOKIE[$name] = $value;
	}
	fclose($fp);
  }

    $rif_sql= "";
    $razon_social= "";
	$direccionFiscal = "";
			 
	if((!empty($rif) && !empty($codigo)) || isset($_FILES['uploadedfile']['size'])) 
	{
			if(!empty($rif) && !empty($codigo))
			{
				$ch = curl_init();
				curl_setopt($ch, CURLOPT_URL, $url);
				curl_setopt($ch, CURLOPT_POST, 3);
				curl_setopt($ch, CURLOPT_POSTFIELDS, "p_rif=".$rif."&p_cedula=&codigo=".$codigo);
				curl_setopt($ch, CURLOPT_FOLLOWLOCATION, 1);
				curl_setopt($ch, CURLOPT_HEADER, false);
				curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);

				$cookie_data =
				implode(
					"; ",
					array_map(
						function($k, $v) {
							return "$k=$v";
						},
						array_keys($_COOKIE),
						array_values($_COOKIE)
					)
				);
				curl_setopt($ch, CURLOPT_COOKIE, $cookie_data);
				
				$remote_server_output = curl_exec($ch);
				$remote_server_output = iconv("Windows-1252", "UTF-8", $remote_server_output);
				//echo $remote_server_output;
						
				$error = curl_error($ch);
				curl_close($ch);

				$re = '/('.$rif.')(.*)\((.*)\)\<\/b\>\<\/font>|('.$rif.')(.*)\<\/b\>\<\/font>/';
				preg_match($re, $remote_server_output, $matches);
				/*
				echo '<h2 align=center> mastches 0: '.$matches[0].'</h1></br>';
				echo '<h2 align=center> mastches 1: '.$matches[1].'</h1></br>';
				echo '<h2 align=center> mastches 2: '.$matches[2].'</h1></br>';
				echo '<h2 align=center> mastches 3: '.$matches[3].'</h1></br>';
				echo '<h2 align=center> mastches 4: '.$matches[4].'</h1></br>';
				echo '<h2 align=center> mastches 5: '.$matches[5].'</h1></br>';
				*/
			 }else if(isset($_FILES['uploadedfile']['size']))
			 {
				 $uploadedfileload="true";
					$msg="";
					$uploadedfile_size=$_FILES['uploadedfile']['size'];
					//echo $_FILES['uploadedfile']['name'];
					if ($_FILES['uploadedfile']['size']>5000000)
					{$msg=$msg."<p align='center'><font color='Red'>El archivo es mayor que 5 MB, debes reduzcirlo antes de subirlo</font></p><br>";
					$uploadedfileload="false";}

					if (!($_FILES['uploadedfile']['type'] =="application/pdf")) 
					{$msg=$msg."<p align='center'><font color='Red'>Tu archivo tiene que ser con formato PDF.</font></p><br>";
					$uploadedfileload="false";}

					$file_name=$_FILES['uploadedfile']['name'];

					$add="uploads/$file_name";
					if($uploadedfileload=="true"){

					if(move_uploaded_file ($_FILES['uploadedfile']['tmp_name'], $add)){
					//echo "<br>Ha sido subido satisfactoriamente<br>";

					$claves = preg_split("[/]", $_FILES['uploadedfile']['type']);
					$ext = $claves[1];

					$imagen = file_get_contents(__DIR__ ."/uploads/".$file_name);
					$imageData = base64_encode($imagen);

						try{
							$client = new Client([
									'base_uri' => 'https://apicontributor20200131051318.azurewebsites.net/',
									'timeout'  => 30.0,
									]);
									// =============================================
									//Hago la llamada al servicio rest, loguear y obtener el Token de Autorization
									   $options = [
										  'json' => [
													 'formatExt' => $ext,
													 'contentEncode64' => $imageData
													]
										]; 

									$res = $client->post('api/contributor', $options);
									
								if ($res->getStatusCode() == '200') //Verifico que me retorne 200 = OK
								{
											 //Convertir el resultado que viene en formato JSON a un array
											$jsonLoginArray = json_decode($res->getBody(), true);
										   echo "<div align='center'><p><font color='black'>Datos Obtenidos</font></p></div>";
										   echo "<h3 align=center>RIF:".$jsonLoginArray['rif']."</h3>";
										   echo "<h3 align=center>Razon Social:".$jsonLoginArray['description']."</h3>";
										   //echo "<h3 align=center>Direccion Fiscal:".$jsonLoginArray['fiscal_address']."</h3>";
										   $rif_sql= $jsonLoginArray['rif'];
										   $razon_social= $jsonLoginArray['description'];
	                                       $direccionFiscal = $jsonLoginArray['fiscal_address'];
								}else{
									 echo "<div align='center'><font color='red'>Error de Requerimiento HTTP : ".$res->getStatusCode()."</font></div><br>";
								}
								
								//echo "<img src='data:".$_FILES['uploadedfile']['type'].";base64,".$imageData."' />"; 
								
						}catch (Exception $e) {
							  echo "<div align='center'><font color='red'>Error de Requerimiento HTTP : ".$e->getMessage()."</font></div><br>";
					   }

					}
					else
					{echo "<p align='center'><font color='Red'>Error al subir el archivo</font></p><br>";}

					}
					else
					{echo $msg;}				 
			 }
		?>
		<form id='form2' name='form2' method='GET' action='indexdemo.php'>
 		
<?php 

 try{     		
        $NotCode = 0;
		/*Validación de Salida*/
		if(!empty($matches[1]) && !empty($matches[2]) && !empty($matches[3]) && empty($matches[4]) && empty($matches[5])) 
			{//echo '<h2 align=center> Información del Contribuyente: '.$matches[0].'</h1></br>';
			 echo '<h3 align=center> RIF: '.$matches[1].'</h2>';
			 echo '<h3 align=center> Razón Social: '.$matches[2].'</h2>';
			 $rif_sql= $matches[1];
			 $razon_social= $matches[2];
			 //echo '<h2 align=center> Nombre Comercial: '.$matches[3].'</h2>';
			 }
		elseif(empty($matches[1]) && empty($matches[2]) && empty($matches[3]) && !empty($matches[4]) && !empty($matches[5])) 
			{echo '<h3 align=center>'.$matches[4].'</h2>';
			 echo '<h3 align=center>'.$matches[5].'</h2>';
			 $rif_sql= $matches[4];
			 $razon_social=$matches[5];}
		else{
			if(empty($rif_sql))
			{
                    $NotCode = 1;
		     echo "<h2 align=center>El código no coincide con la imagen. </h2>";
			 	echo "<input type='hidden' name='p_rif' value='$rif' />";
			 	echo "<p style='text-align: center;'><input style='text-align: center;' class='round' type='submit' name='Submit1' value='Regresar'/></p>";
			}
		}
		
	if((!empty($rif_sql) && !empty($razon_social)) && $razon_social != "&nbsp;No existe el contribuyente solicitado")
       {         
		// Procesar el llamado al POST de la Api de Servicio REST Finalclient
		$reg = 0;
		$razon_social = str_replace("&nbsp;","",$razon_social);
		$razon_social = str_replace("'","´",$razon_social);
		
		$client = new Client([
		    'base_uri' => 'https://gatewayapi20190705051524.azurewebsites.net',
		    //'base_uri' => 'http://192.168.0.73',
			//'base_uri' => 'http://localhost',
		    'timeout'  => 20.0,
			]);
			// =============================================
			//Hago la llamada al servicio rest, loguear y obtener el Token de Autorization
			   $options = [
                  'json' => [
                             'username' => 'pmoya@thefactoryhka.com',
					         'password' => 'Tfhka2019'
                            ]
                ]; 
	   
			$res = $client->post('api-access/Login', $options);
			
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
                                  'rif' => $rif_sql,
                                  'description' => $razon_social, 
								  'fiscal_address' => $direccionFiscal,								
                                  'enable' => 1
                            ],
						'headers' => $header
                       ]; 
					   
					   //Hago el POST al recurso Cliente Final
					   $res = $client->post('api-clients/Finalsclients', $options);
					}else
					{
					    echo "<div align='center'><font color='red'>Error de Autenticaci&oacute;n. Credenciales incorrectas.</font></div><br>";
					}
				  
							
			if($res->getStatusCode() != '201')	//Verifico que me retorne 201 = Created
			{ echo "<p align='center'><font color='Red'>Error ".$res->getStatusCode().". No se pudo importar los datos del contribuyente al SGO.</font></p>";}
			else
			{  $reg = 1; }
	
		}else
		{
		   echo "<div align='center'><font color='red'>Error de Autenticaci&oacute;n. No se pudo obtener el token de autorización.</font></div><br>";
		}
		 
		 
			if($reg == 1)
			{
				 echo "<p align='center'>
				<font color='#008000'>Razón Social de Cliente registrada. Hacer click en [Regresar] para continuar.</font>
				</p>";
			}else
			{
				echo "<input type='hidden' name='p_rif' value='$rif' />";
				echo "<p style='text-align: center;'><input style='text-align: center;' class='round' type='submit' name='Submit1' value='Regresar'/></p>";
			}
	    }else if($NotCode == 0)
		{
			echo "<input type='hidden' name='p_rif' value='$rif' />";
			echo "<p style='text-align: center;'><input style='text-align: center;' class='round' type='submit' name='Submit1' value='Regresar'/></p>";
        }
	   		
?>
				
		</form>
				
		
<?php
	   }catch (Exception $e) {
          echo "<div align='center'><font color='red'>Error de Requerimiento HTTP : ".$e->getMessage()."</font></div><br>";
      }	
	
	} else 
	{
  	 	
 	//"<?php echo $row['nombre'];
	  	
?>
	<form id="form1" action="indexdemo.php" method="POST" name="form1" enctype="multipart/form-data">
	<table style="margin: 0 auto;" width="550">
	<tbody>	
	<table style="margin: 0 auto;" width="500">
	<tr style="text-align: center;">
	<td colspan="1" width="200"><h3 align="center">Validaci&oacute;n SENIAT/Capcha</h3></td>
	<td colspan="1" width="200"><h3 align="center">Validaci&oacute;n SENIAT/RIF PDF</h3></td>
	</tr>
	<tr style="text-align: center;">
	<td colspan="1">RIF del Contribuyente:  <input class="round" maxlength="10" name="p_rif" size="12" type="text" value="<?php echo $rif1;?>" /> </td>
	<td style="text-align: center;" colspan="1"><input name="uploadedfile" type="file" /></td>
	</tr>
	<tr style="text-align: center;">
	<td style="text-align: center;" colspan="1" ><label>C&oacute;digo: </label> <input class="round" maxlength="6" name="codigo" size="10" type="text" /><img align="middle" src="img.php" alt="" border="0" /></td>
	<td style="text-align: center;" colspan="1"><input type="hidden" name="MAX_FILE_SIZE" value="5000000" /></td>
	</tr>
	</table>
	<tr style="text-align: center;">
	<td style="text-align: center;" colspan="1"><label> <input class="round" name="Submit" type="submit" value="Cargar" /> </label></td>
	</tr>
	</tbody>
	</table>
	</form>

</body>
</html> 


<?php
      }

?>



