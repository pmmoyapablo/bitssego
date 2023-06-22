<?php
use GuzzleHttp\Client;

 if(isset($_POST) 
 	&& isset($_POST["versionSystemAdmin"]) // rif
 	&& isset($_POST["socialreason"]) // razon social
	){
		//DevelopersClients
	    $rif = strtoupper($_POST["rif"]);
        $socialreason = $_POST["socialreason"];
		$address = $_POST["address"];
	    $country = $_POST["country"];
	    $state = $_POST["state"];
	    $city = $_POST["city"];
	    $phone = $_POST["phone"];
	    $email = strtolower($_POST["email"]);
	 	//CasesSoftwareHouse
		$contactShape = $_POST["contactShape"];
		$clientType = $_POST["clientType"];
		$page = strtolower($_POST["page"]);
		$systemAdmin = $_POST["systemAdmin"];
		$versionSystemAdmin = $_POST["versionSystemAdmin"];
		$descriptionCase = $_POST["descriptionCase"];
		$otherLanguage = $_POST["otherLanguage"];
		//$employeeId = $_POST["employeeId"]; // por defecto en 0
		$equipments = $_POST["equipmets"];
		//print_r($equipments);
		$systemOperId = $_POST["systemOperId"];
		$statusId = $_POST["statusId"];
		$programLanguageId = $_POST["programLanguageId"];
		$dateRegister = $_POST["dateRegister"];
		$dateLastContact = $_POST["dateLastContact"];

		$registrado = false;

		try{
			$client = new Client([
			    //'base_uri' => 'http://192.168.0.73:81', // servidor test
				'base_uri' => 'http://localhost:81', // servidor local
				//'base_uri' => 'https://localhost:44338',
			    'timeout'  => 20.0,
				]);

				// =============================================
				//Hago la llamada al servicio rest, loguear y obtener el Token de Autorization
				   $options = [
	                  'json' => [
	                             'username' => 'sgove@tfhka.com',
						         'password' => 'Moneda32'
	                            ]
	                ]; 
		   
				$today = date("Y-m-d H:i:s");
				$resLogin = $client->post('api-access/Login', $options);


			if ($resLogin->getStatusCode() == '200') {

		         //Convertir el resultado que viene en formato JSON a un array
		        $jsonLoginArray = json_decode($resLogin->getBody(), true);
	        
		        if($jsonLoginArray['authenticated']){  //Obtenido el Token hago los post en los recursos /Distributors y /Users
				  $header = array('Authorization'=>'Bearer '.$jsonLoginArray['accessToken']);
				  $idExistente = 0;
				  //clientes desarrollador
				 	$optionsDevelopersClients = [
		                'json' => [
									'id' => 0,
									'document' => $rif,
									'description' => $socialreason,
									'address' => $address,
									'country' => $country,
									'state' => $state,
									'city' => $city,
									'phone' => $phone,
									'email' => $email,
									'enable' => 1,
									'creation_date' => $today
		                    	],
						'headers' => $header
	               ]; 

					//consulta si el cliente desarrollador existe
					$existeDevelopersClients = $client->get('api-clients/DevelopersClients', $optionsDevelopersClients);
					$jsonDevelopersArray = json_decode($existeDevelopersClients->getBody(), true);

					//cantidad de clientes desarrolladores
					$cantDevelopers = count($jsonDevelopersArray);
					
					//busqueda de RIF
					for ($i=0; $i < $cantDevelopers ; $i++) { 
						
						if($jsonDevelopersArray[$i]['document'] == $rif){
							$idExistente = intval($jsonDevelopersArray[$i]['id']);
							$registrado = true;
							break;
						}
					}

					 	$optionsDevelopersClients = [
			                'json' => [
										'id' => $idExistente,
										'document' => $rif,
										'description' => $socialreason,
										'address' => $address,
										'country' => $country,
										'state' => $state,
										'city' => $city,
										'phone' => $phone,
										'email' => $email,
										'enable' => 1
			                    	],
							'headers' => $header
		               ]; 	
	                 //POST o PUT del CLIENTE DESARROLLADOR
	               if($registrado){// cliente existe
						//PUT
					   	$resDevelopersClients = $client->put('api-clients/DevelopersClients/'.$idExistente, $optionsDevelopersClients);						
						$jsonDeveloperArray = json_decode($resDevelopersClients->getBody(), true);
						//PUT en User
						
						echo "<p align='center'><font color='#008000'>Actualización de Datos de Cliente Desarrollador Exitoso.</font></p>"; 

	               }else{
		               //POST
					   	$resDevelopersClients = $client->post('api-clients/DevelopersClients', $optionsDevelopersClients);					   	 
						$jsonDeveloperArray = json_decode($resDevelopersClients->getBody(), true);
				        $idExistente = $jsonDeveloperArray['id'];
						
						$respChekUser = $client->get('api-access/Login/'.$email);
						$jsonChekUserArray = json_decode($respChekUser->getBody(), true);
						
						if($respChekUser->getStatusCode() == '204')
						{//Usuario Nuevo
							//POST en User
							 $options1 = [
													'json' => [
															 'id' => 0,                                 
															 'rolId' => 11,
															 'username' => $email,
															 'password' => 'Passwo12',
															 'enable' => 1
																],
															 'headers' => $header
														]; 

							$res = $client->post('api-access/Users', $options1);
							if ($res->getStatusCode() == '201') //Verifico que me retorne 201 = Created
							{
							   //POST en Relacion Developer-Users
							   $jsonUserArray = json_decode($res->getBody(), true);
							   $idUser = $jsonUserArray['id'];
								$options2 = [
								'headers' => $header
														]; 
							   $res = $client->post('api-clients/DevelopersClients/'.$idExistente.'/'.$idUser, $options2);
							} 
						}
						
						echo "<p align='center'><font color='#008000'>Registro de Cliente Desarrollador Exito.</font></p>";
	               }


               		//CASO DE CADA DE SOFTWARE
		         	$idDeveloper = $idExistente;	               		
					//print_r("<br>id DEVELOPER: ".$idDeveloper);
	               //casos de casa de software
					$optionsCases = [
	                    'json' => [
								  'id' => 0,
								  'contactShape' => $contactShape,
								  'clientType' => $clientType,
								  'page' => $page,
								  'systemAdmin' => $systemAdmin,
								  'versionSystemAdmin' => $versionSystemAdmin,
								  'descriptionCase' => $descriptionCase,
								  'otherLanguage' => $otherLanguage,
								  'employeeId' => 0,
								  'developersClientsId' => $idDeveloper,
								  'systemOperId' => $systemOperId,
								  'statusId' => $statusId,
								  'programLanguageId' => $programLanguageId,
								  'dateRegister' => $today,
								  'dateLastContact' => $today
	                        	],
						'headers' => $header
	                       ]; 
				   	//POST CASO DE CASA DE SOFTWARE
	               // if(!$registrado){//si no esta registrado hace el POST
						$resCases = $client->post('api-utilities/CasesSoftwareHouses', $optionsCases);
	               // }

				}else{
				    echo "<div align='center'><font color='red'>Error de Autenticaci&oacute;n. Credenciales incorrectas.</font></div><br>";
				}


				if($resDevelopersClients->getStatusCode() != '204' && $resCases->getStatusCode() != '201'){ 
					echo "<p align='center'><font color='Red'>Error ".$resDevelopersClients->getStatusCode().". No se pudo registrar o actualizar los datos de Cliente Desarrollador.</font></p>";
				}else{
                                    //POST en el Recurso CasesProducts
                                     $jsonCaseArray = json_decode($resCases->getBody(), true);
									 foreach($equipments as $key => $value)
									 {
                                        $optionsCasesProducts = [
                                          'json' => [
                                                      'id' => 0,
                                                      'caseSoftwareHouseId' => $jsonCaseArray['id'],
                                                      'productId' => $value
                                                    ],
                                                            'headers' => $header
                                           ]; 
                                        $resCasesProducts = $client->post('api-utilities/CasesProducts', $optionsCasesProducts);
									 }
                                    
			        echo "<p align='center'><font color='#008000'>Registro de Caso Exitoso.</font></p>"; 
			    }

			}else{
				//ERROR DE LOGIN
			   echo "<div align='center'><font color='red'>Error de Autenticaci&oacute;n. No se pudo obtener el token de autorización.</font></div><br>";
			}

		}catch (Exception $e) {		
			//EXCEPCION
	          echo "<div align='center'><font color='red'>Error de Requerimiento HTTP : ".$e->getMessage()."</font></div><br>";
	   	}

 }
 
?>