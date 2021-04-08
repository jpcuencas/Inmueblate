/******** FOTO NOTICIA ********/

	var fotosPag = 5; // Número de fotos que sale en la paginación.
	function fotoNoticia(id,num,numTotal) {
		fotosN = document.getElementsByTagName('div');
		fotoOn = 1;
		fotoExp = new RegExp(id + "-");
		for(i=0;i<fotosN.length;i++) {
			if(fotosN[i].id.indexOf(id) == 0) {
				fotoOn = parseInt(fotosN[i].id.replace(fotoExp, ""));
				if(fotosN[i].style.display == "") {
					if(num == '+') num = fotoOn + 1;
					if(num == '-') num = fotoOn - 1;
				}
				fotosN[i].style.display = 'none';
			}
		}
		if(num == 0) num = numTotal;
		if((num > numTotal) || isNaN(num)) num = 1;
		if(fotoN = document.getElementById(id + '-' + num)) fotoN.style.display = "";
		indicePag = Math.ceil(num/fotosPag) - 1;
		for(i=1;i<=fotosPag;i++) {
			if(pag = document.getElementById(id + '-pag-' + i)) {
				pag.className = "";
				pagNum = i + (indicePag * fotosPag);
				if(pagNum > numTotal) {
					pag.innerHTML = "&nbsp;&nbsp;";
					pag.href = "#";
				}
				else {
					pag.innerHTML = i + (indicePag * fotosPag);
					pag.href = "JavaScript:fotoNoticia('" + id + "'," + pagNum + "," + numTotal + ");";
				}
			}
		}
		numPag = ((num - 1) % fotosPag) + 1;
		if(pag = document.getElementById(id + '-pag-' + numPag)) pag.className = "activo";
	}

	/******** FIN FOTO NOTICIA ********/
	/******** RANDOM ********/

function aleatorio(inferior,superior){
numPosibilidades = superior - inferior;
rand = Math.random() * numPosibilidades;
rand = Math.round(rand);
return parseInt(inferior) + rand;
}

/******** FIN RANDOM ********/

/******** GOOGLE  ********/
	function cs() {window.status=''};
	function ss(urlVisible){window.status=urlVisible;return true;};
	
	function google_ad_request_done(google_ads) {
		var i;
		var publi ='';
		accip = "off";
		if(google_ads.length > 0) {
			publi+='<div class="adds">';
			publi+='<div class="estilo_tit"><a href="'+google_info.feedback_url+'">Anuncios <strong>Google</strong></a></div>';
			publi+='<table class="addscontent" cellpadding="0" cellspacing="0">';
			for(i = 0; i < google_ads.length; ++i) {
				publi+='<tr>';
				publi+='<td class="estilo_txt">';
				publi+='<a href=\''+ google_ads[i].url + '\' target="_blank" onMouseOver="return ss(\'' + google_ads[i].visible_url + '\')" onMouseOut="cs()">';

				publi+='<span class="estilo_lnk">';
				publi+=google_ads[i].line1;
				publi+='</span></a>';
				publi+='<span class="estilo_descripcion">';
				publi+=google_ads[i].line2 + '&nbsp;';
				publi+=google_ads[i].line3 + '&nbsp;';
				publi+='</span>';
				publi+='<a href=\''+ google_ads[i].url + '\' target="_blank" onMouseOver="return ss(\'' + google_ads[i].visible_url + '\')" onMouseOut="cs()">';
				publi+='<span class="estilo_url">';
				publi+=google_ads[i].visible_url;
				publi+='</span></a></td></tr>';
			}
			publi+='</table></div>';
			if(contNoxtrum = window.document.getElementById("publi1_noxtrum"))
				contNoxtrum.innerHTML = publi;
		}
	}
/******** GOOGLE  ********/	
	
       /******** MODULOS METHODE ********/
                                
        function canalesHoy(id,num,color) {
                colorPestana = ""
                if(!isNaN(color))
                        colorPestana = " pestcanal-" + color;
                pestanaOn = id + "-pestana-" + num;
                contenidoOn = id + "-contenido-" + num;
                bottomOn = id + "-bottom-" + num;
                contenidosN = document.getElementsByTagName('div');
                for(i=0;i<contenidosN.length;i++) {
                        if(contenidosN[i].id.indexOf(id) == 0) {
                                if((contenidosN[i].id == contenidoOn) || (contenidosN[i].id == bottomOn))
                                        contenidosN[i].style.display = "";
                                else
                                        contenidosN[i].style.display = "none";
                        }
                }
                pestanasN = document.getElementsByTagName('a');
                for(i=0;i<pestanasN.length;i++) {
                        if(pestanasN[i].id.indexOf(id) == 0) {
                                if(pestanasN[i].id == pestanaOn)
                                        pestanasN[i].className = "activo";
                                else
                                        pestanasN[i].className = "";
                        }
                }
                if(objColor = document.getElementById('color-' + id))
                        objColor.className = "modulocanaleshoy" + colorPestana;
        }

        function canalesClasi(id,canal) {
                contenidosN = document.getElementsByTagName('div');
                for(i=0;i<contenidosN.length;i++) {
                        if(contenidosN[i].id.indexOf(id) == 0) {
                                if(contenidosN[i].id == id + "-" + canal)
                                        contenidosN[i].style.display = "";
                                else
                                        contenidosN[i].style.display = "none";
                        }
                }
                pestanasN = document.getElementsByTagName('a');
                for(i=0;i<pestanasN.length;i++) {
                        if(pestanasN[i].id.indexOf(id) == 0) {
                                if(pestanasN[i].id == id + "-pestana-" + canal)
                                        pestanasN[i].className = "activo " + canal;
                                else
                                        pestanasN[i].className = "";
                        }
                }
        }

        function canalesInfo(id,num,numTotal) {
                contenidoOn = 1;
                contenidoExp = new RegExp(id + "-(contenido|fotografia)-");
                contenidosN = document.getElementsByTagName('div');
                for(i=0;i<contenidosN.length;i++) {
                        if(contenidosN[i].id.indexOf(id) == 0) {
                                contenidoOn = parseInt(contenidosN[i].id.replace(contenidoExp, ""));
                                if(contenidosN[i].style.display == "") {
                                        if(num == '+') num = contenidoOn + 1;
                                        if(num == '-') num = contenidoOn - 1;
                                }
                                contenidosN[i].style.display = "none";
                        }
                }
                if(num == 0) num = numTotal;
                if((num > numTotal) || isNaN(num)) num = 1;
                if(contenidoN = document.getElementById(id + '-fotografia-' + num)) contenidoN.style.display = "";
                if(contenidoN = document.getElementById(id + '-contenido-' + num)) contenidoN.style.display = "";
                numTxt = num.toString();
                if(num < 10)
                        numTxt = "0" + numTxt;
                if(contenidoN = document.getElementById(id + '-num')) contenidoN.innerHTML = numTxt;
        }

        function servicios(id,num) {
                contenidosN = document.getElementsByTagName('div');
                for(i=0;i<contenidosN.length;i++) {
                        if(contenidosN[i].id.indexOf(id + "-contenido-") == 0) {
                                if(contenidosN[i].id == id + "-contenido-" + num)
                                        contenidosN[i].style.display = "";
                                else
                                        contenidosN[i].style.display = "none";
                        }
                }
                pestanasN = document.getElementsByTagName('li');
                for(i=0;i<pestanasN.length;i++) {
                        if(pestanasN[i].id.indexOf(id + "-pestana-") == 0) {
                                if(pestanasN[i].id == id + "-pestana-" + num)
                                        pestanasN[i].className = "activa";
                                else
                                        pestanasN[i].className = "";
                        }
                }
        }

        /******** MODULOS METHODE  ********/	

	/************ AJAX **********/
	
	function createRequestObject() {
		var ro;
		var browser = navigator.appName;
		
		if(browser == "Microsoft Internet Explorer"){
			ro = new ActiveXObject("Microsoft.XMLHTTP");
		}
		else{
			ro = new XMLHttpRequest();
		}
		return ro;
	}  
	
	/************ FIN AJAX **********/



function votarticulo(puntos) {
		
		var direccion;
		
		if (window.document.location.href.indexOf('?') > 0) {
			var campos = window.document.location.href.split('?');
			direccion = campos[0];
		}
		else {
			direccion = window.document.location.href;
		}	
		
		var http = createRequestObject();
		http.open("get", "/backend/votaciones/votar.php?puntos=" + puntos + "&url=" + direccion + "&r=" + Math.random());
		http.onreadystatechange = function () {
			if(http.readyState == 4){
				if (http.responseText) {
					gracias = "<div class=label>Gracias por votar</div>";
					document.getElementById('contenidoestrellas').innerHTML = gracias;
					getEstrellas();
					getVotos();
						
				}
			}	
		};
		http.send(null);		
	}
	
	function getEstrellas() {
		
		var direccion;
		
		if (window.document.location.href.indexOf('?') > 0) {
			var campos = window.document.location.href.split('?');
			direccion = campos[0];
		}
		else {
			direccion = window.document.location.href;
		}
		
		var http = createRequestObject();
		http.open("get", "/backend/votaciones/estrellas.php?url=" + direccion);
		http.onreadystatechange = function () {
			if(http.readyState == 4){
				if (http.responseText) {
					var estrellas = http.responseText;
					
					if (estrellas.indexOf(".")) {
			
						campos = estrellas.split(".");
						estrellas = campos[0];	
						var media = (campos[1] > 0) ? 1 : 0;
					}
					
					var contenido = '';
					
					for (i = 0; i < estrellas; i++) {
						contenido += '<img src="/img/star_on.gif" alt="' + i +' votos" />';
					}
					
					if (media == 1) {
						contenido += '<img src="/img/star_on_md.gif" alt="' + estrellas +' votos" />';
						estrellas++;
					}
					
					for (i = estrellas; i < 5; i++) {
						contenido += '<img src="/img/star_off.gif" alt="' + i +' votos" />';	
					}
					
					window.document.getElementById('resultados-votos').innerHTML = contenido;
						
				}
			}	
		};
		http.send(null);
			
	}
	
	function getVotos() {
		
		var direccion;
		
		if (window.document.location.href.indexOf('?') > 0) {
			var campos = window.document.location.href.split('?');
			direccion = campos[0];
		}
		else {
			direccion = window.document.location.href;
		}
		
		var http = createRequestObject();
		//http.open("get", "/backend/votaciones/votos.php?url=" + direccion +"&r=" + Math.random());
		http.open("get", "/backend/votaciones/votos.php?url=" + direccion);
		http.onreadystatechange = function () {
			if(http.readyState == 4){
				if (http.responseText) {
					var votos = http.responseText;
					if (votos == 1) {
						window.document.getElementById('numvotos-votos').innerHTML = votos + ' voto';
					}
					else {
						window.document.getElementById('numvotos-votos').innerHTML = votos + ' votos';
					}
				}
			}	
		};
		http.send(null);
			
	}

	var http = createRequestObject();
                                
        http.open('get', '/acceso.php?pag=' + window.document.location.href + '&resolucion=' + screen.width + 'x' + screen.height + '&r=' + Math.random());
        http.send(null);

	/************ COOKIES ***********/

        function setCookie(name, value, expires, path, domain, secure) {
                var curCookie = name + "=" + escape(value) + ((expires) ? "; expires=" + expires : "") + ((path) ? "; path=" + path : "") + ((domain) ? "; domain=" + domain : "") + ((secure) ? "; secure" : "");
                document.cookie = curCookie;
        }

        function getCookie(name) {
                var dc = document.cookie;
                var prefix = name + "=";
                var begin = dc.indexOf("; " + prefix);
                if (begin == -1) {
                        begin = dc.indexOf(prefix);
                if (begin != 0) return null;
                } else
                        begin += 2;
                var end = document.cookie.indexOf(";", begin);
                if (end == -1)
                        end = dc.length;
                return unescape(dc.substring(begin + prefix.length, end));
        }

        /************ FIN COOKIES ***********/


function presentarticker(capa){
        document.getElementById('tickereconomiaoff').style.display = 'none';
        document.getElementById('tickereconomia').style.display = 'block';
}

function tienda(modulo,maximo){
                for (iq = 1; iq < maximo+1; iq++) {
                        bloque = "modulotienda" + iq;
                        //alert('oculto ' + bloque);
                        document.getElementById(bloque).style.display = 'none';
                }
       
                presentar = "modulotienda" + modulo;
                //alert('presento ' + presentar );
                document.getElementById(presentar).style.display = 'block';
       
	}

/************ TEXTLINK ***********/

function activaTextLink(){
$(document).ready(function() {
if( $("#publiEspecial").css("display") == 'none' ) {
$("#publiEspecial").css("display","");
}
});
}

/************ FIN TEXTLINK ***********/

/************ ENCUESTAS MULTIPLES ***********/

function validaEncMultiple(poll_id) {
	var frm = eval("window.document.encuesta_" + poll_id);
	var maxr = frm.maxrespuestas.value;
	var nump = frm.numpreguntas.value;
	var i = 1;
	var opt = "";
	var numrespuestas = 0;
	
	for(i=nump; i>=1; i--) {
		eval("opt = frm.option_id_" + i);
		if(opt.checked) {
			numrespuestas++;
		}
	}

	if(maxr && nump) {
		if(numrespuestas > maxr) {
			alert("Sólo se pueden marcar " + maxr + " respuestas posibles");
			return;
		}
	}
	frm.submit();
}


/************ FIN ENCUESTAS MULTIPLES ***********/

// CODIGO GOOGLE

// anadimos este codigo de google, para hacer el tracking de analytics 
// Copyright 2011 Google Inc. All Rights Reserved.
/**
 * @fileoverview A simple script to automatically track Facebook and Twitter
 * buttons using Google Analytics social tracking feature.
 * @author api.nickm@google.com (Nick Mihailovski)
 */



/**
 * Namespace.
 * @type {Object}.
 */
var _ga = _ga || {};



/**
 * Ensure global _gaq Google Anlaytics queue has be initialized.
 * @type {Array}
 */
var _gaq = _gaq || [];



/**
 * Helper method to track social features. This assumes all the social
 * scripts / apis are loaded synchronously. If they are loaded async,
 * you might need to add the nextwork specific tracking call to the
 * a callback once the network's script has loaded.
 * @param {string} opt_pageUrl An optional URL to associate the social
 *     tracking with a particular page.
 * @param {string} opt_trackerName An optional name for the tracker object.
 */
_ga.trackSocial = function(opt_pageUrl, opt_trackerName) {
  _ga.trackFacebook(opt_pageUrl, opt_trackerName);
  _ga.trackTwitter(opt_pageUrl, opt_trackerName);
};



/**
 * Tracks Facebook likes, unlikes and sends by suscribing to the Facebook
 * JSAPI event model. Note: This will not track facebook buttons using the
 * iFrame method.
 * @param {string} opt_pageUrl An optional URL to associate the social
 *     tracking with a particular page.
 * @param {string} opt_trackerName An optional name for the tracker object.
 */
_ga.trackFacebook = function(opt_pageUrl, opt_trackerName) {
  var trackerName = _ga.buildTrackerName_(opt_trackerName);
  try {
    if (FB && FB.Event && FB.Event.subscribe) {
      FB.Event.subscribe('edge.create', function(targetUrl) {
        _gaq.push([trackerName + '_trackSocial', 'facebook', 'like',
            targetUrl, opt_pageUrl]);
      });
      FB.Event.subscribe('edge.remove', function(targetUrl) {
        _gaq.push([trackerName + '_trackSocial', 'facebook', 'unlike',
            targetUrl, opt_pageUrl]);
      });
      FB.Event.subscribe('message.send', function(targetUrl) {
        _gaq.push([trackerName + '_trackSocial', 'facebook', 'send',
            targetUrl, opt_pageUrl]);
      });
    }
  } catch (e) {}
};



/**
 * Returns the normalized tracker name configuration parameter.
 * @param {string} opt_trackerName An optional name for the tracker object.
 * @return {string} If opt_trackerName is set, then the value appended with
 *     a . Otherwise an empty string.
 * @private
 */
_ga.buildTrackerName_ = function(opt_trackerName) {
  return opt_trackerName ? opt_trackerName + '.' : '';
};



/**
 * Tracks everytime a user clicks on a tweet button from Twitter.
 * This subscribes to the Twitter JS API event mechanism to listen for
 * clicks coming from this page. Details here:
 * http://dev.twitter.com/pages/intents-events#click
 * This method should be called once the twitter API has loaded.
 * @param {string} opt_pageUrl An optional URL to associate the social
 *     tracking with a particular page.
 * @param {string} opt_trackerName An optional name for the tracker object.
 */
_ga.trackTwitter = function(opt_pageUrl, opt_trackerName) {
  var trackerName = _ga.buildTrackerName_(opt_trackerName);
  try {
    if (twttr && twttr.events && twttr.events.bind) {
      twttr.events.bind('tweet', function(event) {
        if (event) {
          var targetUrl; // Default value is undefined.
          if (event.target && event.target.nodeName == 'IFRAME') {
            targetUrl = _ga.extractParamFromUri_(event.target.src, 'url');
          }
          _gaq.push([trackerName + '_trackSocial', 'twitter', 'tweet',
            targetUrl, opt_pageUrl]);
        }
      });
    }
  } catch (e) {}
};



/**
 * Extracts a query parameter value from a URI.
 * @param {string} uri The URI from which to extract the parameter.
 * @param {string} paramName The name of the query paramater to extract.
 * @return {string} The un-encoded value of the query paramater. underfined
 *     if there is no URI parameter.
 * @private
 */
_ga.extractParamFromUri_ = function(uri, paramName) {
  if (!uri) {
    return;
  }
  var uri = uri.split('#')[0];  // Remove anchor.
  var parts = uri.split('?');  // Check for query params.
  if (parts.length == 1) {
    return;
  }
  var query = decodeURI(parts[1]);


  // Find url param.
  paramName += '=';
  var params = query.split('&');
  for (var i = 0, param; param = params[i]; ++i) {
    if (param.indexOf(paramName) === 0) {
      return unescape(param.split('=')[1]);
    }
  }
  return;
};