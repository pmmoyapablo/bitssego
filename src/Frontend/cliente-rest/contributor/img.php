<?php
	$url = "http://contribuyente.seniat.gob.ve/BuscaRif/Captcha.jpg";

	
	$ch = curl_init();
	curl_setopt($ch, CURLOPT_URL, $url);
	curl_setopt($ch, CURLOPT_HEADER  ,1);
	curl_setopt($ch, CURLOPT_RETURNTRANSFER  ,1);
	curl_setopt($ch, CURLOPT_FOLLOWLOCATION  ,1);
	curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, 0);
	curl_setopt($ch, CURLINFO_HEADER_OUT, true);

	$remote_server_output = curl_exec($ch);
	curl_close($ch);

	list($header, $body) = explode("\r\n\r\n", $remote_server_output, 2);
	echo $body;

	preg_match_all('/^Set-Cookie:\s*([^\r\n]*)/mi', $remote_server_output, $ms);

	$cookies = array();
	$data = "";
	foreach ($ms[1] as $m) {		
		list($name, $value) = explode('=', $m, 2);		
		//$cookies[$name] = $value;
		$data = $name."|".$value;
		$_COOKIE[$name] = $value;
		setcookie($name , $value,  time()+3600, "/");
	}
	
	 $nombre_archivo = "cookie.txt"; 
 
    if(file_exists($nombre_archivo))
    {
		unlink( $nombre_archivo);
        $mensaje = "El Archivo $nombre_archivo se ha modificado";
    }
 
    else
    {
        $mensaje = "El Archivo $nombre_archivo se ha creado";
    }
 
    if($archivo = fopen($nombre_archivo, "w"))
    {
        if(fwrite($archivo,$data))
        {
            //echo "Se ha ejecutado correctamente";
        }
        else
        {
            //echo "Ha habido un problema al crear el archivo";
        }
 
        fclose($archivo);
    }

?>