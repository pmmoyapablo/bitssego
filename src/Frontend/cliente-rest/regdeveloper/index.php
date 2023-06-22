<?php
@include('ListGetAll.php');
?>

<html>
	<head>
		<meta charset="UTF-8">
		<meta name="viewport" content="width=device-width, initial-scale=1.0">
		<meta http-equiv="X-UA-Compatible" content="ie-edge">
		<title>Casos Casa de Software</title>		
		<style type="text/css">
			form#freg {
			margin:auto;
			padding: 5px;
			width: 600px;
			border:solid 10px #EEEEEE;
			border-radius: 5px;
			-webkit-border-radius: 5px;
			-moz-border-radius: 5px;
			}

			form#freg fieldset {
			border: none;
			}

			form#freg [required]{
			/*border:solid 2px red;*/
			}
		</style>
		<link rel="stylesheet" href="../materialize/css/materialize.min.css">
		<link rel = "stylesheet" href = "../materialize/css/ajax/materialize.min.css">
		<script type = "text/javascript" src = "../materialize/js/jquery-2.1.1.min.js"></script>
		<script src = "../materialize/js/ajax/materialize.min.js"></script> 
		<script type = "text/javascript" src = "../materialize/js/validateRegDeveloper.js"></script>
	</head>
	<body>
		<div class="container">
			<div class="section">
				<h3>
					<center>Datos del Cliente Desarrollador</center>
				</h3>
				<form name="freg" id="freg" action="index.php" method="POST" >
					<table>
						<!-- RIF -->
						<tr>
							<td><label for="rif">RIF: <i style="color: red;">*</i></label></td>
							<td><input type="text" name="rif" id="rif" minlength="7" maxlength="10" oninput="validarRIF(this.value);" placeholder="Ej. V123456789" title="Tipo (V-E-J-P-G) + Numeración RIF" required>
								<p class="msg_RIF" style="color: red;"></p>
							</td>

						</tr>						
						<!-- RAZON SOCIAL -->
						<tr>
							<td><label for="socialreason">Razón Social: <i style="color: red;">*</i></label></td>
							<td><input type="text" name="socialreason" id="socialreason" oninput="this.value=this.value.replace(/[^0-9a-zA-ZäÄëËïÏöÖüÜáéíóúÁÉÍÓÚñÑ,.-\s]/g,'').replace(/\s{2,}/g,' ').replace(/^\s/g,'')" placeholder="Ingrese Nombre Completo o Razón Social" maxlength="100" required>
							</td>
						</tr>
						<!-- PAIS -->
						<tr>
							<td><label for="country">Pais: <i style="color: red;">*</i></label></td>
							<td><input type="text" name="country" id="country" oninput="this.value=this.value.replace(/[^0-9a-zA-ZäÄëËïÏöÖüÜáéíóúÁÉÍÓÚñÑ,.-\s]/g,'').replace(/\s{2,}/g,' ').replace(/^\s/g,'')" placeholder="Ingrese Pais" maxlength="100" required>
							</td>
						</tr>
						<!-- ESTADO -->
						<tr>
							<td><label for="state">Estado: <i style="color: red;">*</i></label></td>
							<td><input type="text" name="state" id="state" oninput="this.value=this.value.replace(/[^0-9a-zA-ZäÄëËïÏöÖüÜáéíóúÁÉÍÓÚñÑ,.-\s]/g,'').replace(/\s{2,}/g,' ').replace(/^\s/g,'')" placeholder="Ingrese Estado" maxlength="100" required>
							</td>
						</tr>
						<!-- CIUDAD -->
						<tr>
							<td><label for="city">Ciudad: <i style="color: red;">*</i></label></td>
							<td><input type="text" name="city" id="city" oninput="this.value=this.value.replace(/[^0-9a-zA-ZäÄëËïÏöÖüÜáéíóúÁÉÍÓÚñÑ,.-\s]/g,'').replace(/\s{2,}/g,' ').replace(/^\s/g,'')" placeholder="Ingrese Ciudad" maxlength="100" required>
							</td>
						</tr>
						<!-- DIRECCION -->
						<tr>
							<td><label for="address">Dirección: <i style="color: red;">*</i></label></td>
							<td><input type="text" name="address" id="address" oninput="this.value=this.value.replace(/[^0-9a-zA-ZäÄëËïÏöÖüÜáéíóúÁÉÍÓÚñÑ,.-\s]/g,'').replace(/\s{2,}/g,' ').replace(/^\s/g,'')" placeholder="Ingrese Dirección" maxlength="150" required>
							</td>
						</tr>
						<!-- CORREO ELECTRONICO -->
						<tr>
							<td><label for="email">Correo Electrónico: <i style="color: red;">*</i></label></td>
							<td><input type="text" name="email" id="email" 
								oninput="validarEmail(this.value);"
								placeholder="Ej. pedroperez@dominio.com" maxlength="100" required>
								<p class="msg_email" style="color: red;"></p>
							</td>
						</tr>
						<!-- NUMERO DE TELEFONO -->
						<tr>
							<td><label for="phone">Número Teléfono: <i style="color: red;">*</i></label></td>
							<td><input type="text" name="phone" id="phone" minlength="7" maxlength="13" oninput="this.value=this.value.replace(/[^0-9+\s]/g,'').replace(/\s{2,}/g,' ').replace(/^\s/g,'')" placeholder="Ingrese Numero Telefonico de la Empresa" required>
							</td>
						</tr>
						<!-- FORMA DE CONTACTO PREFERIDA -->
						<tr>
							<td><label for="contactShape">Forma de contacto preferida: <i style="color: red;">*</i></label></td>
							<td>
								<select class="browser-default" name="contactShape" id="contactShape" required>
									<option value="" disabled selected>Seleccione...</option>
									<option value="Telefono">Telefono</option>
									<option value="Correo_Eletronico">Correo Electrónico</option>
								</select>
							</td>
						</tr>

						<!-- FORMA DE CONTACTO PREFERIDA -->
						<tr>
							<td><label for="clientType">Tipo de Cliente: <i style="color: red;">*</i></label></td>
							<td>
								<select class="browser-default" name="clientType" id="clientType" required>
									<option value="0" disabled selected>Seleccione...</option>
									<option value="1">Fabricante de Software</option>
									<option value="2">Aliado Comercial de Venta</option>
									<option value="3">Desarrollo Independiente</option>
								</select>
							</td>
						</tr>


                        <!-- NOMBRE DEL SOFTWARE INTEGRADO -->
						<tr>
							<td><label for="systemAdmin">Nombre del Software Integrado: <i style="color: red;">*</i></label></td>
							<td><input type="text" name="systemAdmin" id="systemAdmin" oninput="this.value=this.value.replace(/[^0-9a-zA-ZäÄëËïÏöÖüÜáéíóúÁÉÍÓÚñÑ,.-\s]/g,'').replace(/\s{2,}/g,' ').replace(/^\s/g,'')" placeholder="Ej. Sistema ERP o POS" maxlength="255" required></td>
						</tr>
						<!-- ULTIMA VERSION DEL SOFTWARE INTEGRADO -->
						<tr>
							<td><label for="versionSystemAdmin">Última Versión del Software Integrado: <i style="color: red;">*</i></label></td>
							<td><input type="text" name="versionSystemAdmin" id="versionSystemAdmin" oninput="this.value=this.value.replace(/[^0-9.-\s]/g,'').replace(/\s{2,}/g,' ').replace(/^\s/g,'')"placeholder="Ej. 1.0.0" maxlength="20" required></td>
						</tr>
						<!-- PAGINA WEB -->
						<tr>
							<td><label for="page">Página Web: <i style="color: red;">*</i></label></td>
							<td><input type="text" name="page" id="page" oninput="this.value=this.value.replace(/[^0-9a-zA-Z.-_\s]/g,'').replace(/\s{2,}/g,' ').replace(/^\s/g,'')" placeholder="Ingrese Página Web" maxlength="255" required></td>
						</tr>
						<!-- SISTEMAS OPERATIVOS -->
						<tr>
							<td><label for="systemOperId">Sistemas Operativos: <i style="color: red;">*</i></label></td>
							<td>
							    <select class="browser-default" name="systemOperId" id="systemOperId"  value="{{ old('systemOperId') }}" size="1" maxlength="1" required="required">
                                    <option value="" disabled selected>Seleccione...</option>
                                    <?php
	                                    for($i=0; $i<count($array_SystemOpers); $i++){
	                                    	echo "<option value=".$array_SystemOpers[$i]['id'].">".$array_SystemOpers[$i]['name']." </option>";
	                                    }
                                    ?>
								</select>
							</td>
						</tr> 
						<!-- ESTATUS INTEGRACION -->
						<tr style="display: none">
							<td><label for="statusId">Estatus: <i style="color: red;">*</i></label></td>
							<td>
							     <select class="browser-default" name="statusId" id="statusId"  value="{{ old('statusId') }}" size="1" maxlength="1" required="required">
                                    <option value="" disabled selected>Seleccione...</option>
                                    <?php
	                                    for($i=0; $i<count($array_StatusIntegrations); $i++){
	                                    	echo "<option value=".$array_StatusIntegrations[$i]['id'];
	                                    	if($i==0){echo" selected ";}// seleccion por defecto
	                                    	echo ">".$array_StatusIntegrations[$i]['name']." </option>";
	                                    }
                                    ?>
								</select>
							</td>
						</tr>
						<!-- LENGUAJES DE PROGRAMACION -->
						<tr>
							<td><label for="programLanguageId">Lenguajes de Programación: <i style="color: red;">*</i></label></td>
							<td>
							    <select class="browser-default" name="programLanguageId" id="programLanguageId"  value="{{ old('programLanguageId') }}" size="1" maxlength="1" required="required">
                                    <option value="" disabled selected>Seleccione...</option>
                                    <?php
	                                    for($i=0; $i<count($array_ProgramLanguages); $i++){
	                                    	echo "<option value=".$array_ProgramLanguages[$i]['id'].">".$array_ProgramLanguages[$i]['name']." </option>";
	                                    }
                                    ?>
								</select>
							</td>
						</tr>
						<!-- OTRO LENGUAJE -->
						<tr>
							<td><label for="otherLanguage">Indique Otro Lenguaje: <i style="color: red;">*</i></label></td>
							<td><input type="text" name="otherLanguage" id="otherLanguage" oninput="this.value=this.value.replace(/[^0-9a-zA-ZäÄëËïÏöÖüÜáéíóúÁÉÍÓÚñÑ,.-#+\s]/g,'').replace(/\s{2,}/g,' ').replace(/^\s/g,'')" placeholder="Ingrese Lenguaje" required></td>
						</tr>	
						<!-- EQUIPOS FISCALES -->					
						<tr>
							<td><label for="TaxMachines">Equipos Fiscales con los que está integrado: <i style="color: red;">*</i></label>
							</td>
							<td>
                                <select required="required" multiple name="equipmets[]" id="equipmets">
                                    <option value="" disabled selected>Seleccione...</option>
                                    <?php
	                                    for($i=0; $i<count($array_TaxMachines); $i++){
	                                    	echo "<option value=".$array_TaxMachines[$i]['id'].">".$array_TaxMachines[$i]['model']['name']." </option>";
	                                    }
                                    ?>
								</select>
							</td>
						</tr>		
						<!-- COMENTARIOS -->
						<tr>
							<td><label for="descriptionCase">Descripción del Caso: <i style="color: red;">*</i></label></td>
							<td>
								<textarea class="materialize-textarea" name="descriptionCase" id="descriptionCase" oninput="this.value=this.value.replace(/[^0-9a-zA-ZäÄëËïÏöÖüÜáéíóúÁÉÍÓÚñÑ,.-\s]/g,'').replace(/\s{2,}/g,' ').replace(/^\s/g,'')" placeholder="Ingrese Descripción del Caso" maxlength="150" required></textarea>
							</td>
						</tr>
					</table>
					<br>
					<center>
						<button type="submit" class ="btn btn-block btn-success btn-lg" id="bot_guardar" style="color:white;" disabled="">Registrar</button>
					</center>
				</form>
				<?php
				@include('validation.php');
				?>
			</div>
		</div>
	</body>
</html>