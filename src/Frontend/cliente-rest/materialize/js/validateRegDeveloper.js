         $(document).ready(function() {
            $('select').material_select();
         });


         // valor por defecto de Estatus
            var elem = document.querySelector('#statusId');
            var instances = M.FormSelect.init(elem);
                //alert(instances);         
            document.querySelector('#statusId option[value="1"]').setAttribute('selected', 'selected');
            M.FormSelect.init(elem);


            function validarEmail(valor) {
              if (/^([a-zA-Z0-9._-]+[a-zA-Z0-9_]@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}){1}(;[a-zA-Z0-9._-]+[a-zA-Z0-9_]@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}){0,4}$/.test(valor)){
                $(".msg_email").html("");
                $('#bot_guardar').removeAttr("disabled"); 
              } else {
                $(".msg_email").html("<b>Disculpe, formato de correo Inválido o Incorrecto.</b>");
                $('#bot_guardar').attr('disabled','disabled');
              }
            }


            function validarRIF(valor) {
              if (/^([VEJPGvejpg]{1}[0-9]{7,9})$/.test(valor)){
                $(".msg_RIF").html("");
                $('#bot_guardar').removeAttr("disabled"); 
              } else {
                $(".msg_RIF").html("<b>Disculpe, formato de RIF Inválido o Incorrecto. </b><br>(Primer caracter el Tipo de RIF, sin espacios en blanco y sin caracteres especiales).");
                $('#bot_guardar').attr('disabled','disabled');
              }
            }