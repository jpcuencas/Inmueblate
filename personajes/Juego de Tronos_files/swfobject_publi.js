// Carga de las librerias para evitar crossdomain en IE7
/*easyXDM.debug.js*/
(function(e,t,n,r,i,s){function E(e,t){var n=typeof e[t];return n=="function"||!!(n=="object"&&e[t])||n=="unknown"}function S(e,t){return!!(typeof e[t]=="object"&&e[t])}function x(e){return Object.prototype.toString.call(e)==="[object Array]"}function T(){try{var e=new ActiveXObject("ShockwaveFlash.ShockwaveFlash");y=Array.prototype.slice.call(e.GetVariable("$version").match(/(\d+),(\d+),(\d+),(\d+)/),1);b=parseInt(y[0],10)>9&&parseInt(y[1],10)>0;e=null;return true}catch(t){return false}}function O(){if(k){return}k=true;w("firing dom_onReady");for(var e=0;e<L.length;e++){L[e]()}L.length=0}function _(e,t){if(k){e.call(t);return}L.push(function(){e.call(t)})}function D(){var e=parent;if(h!==""){for(var t=0,n=h.split(".");t<n.length;t++){if(!e){throw new Error(n.slice(0,t+1).join(".")+" is not an object")}e=e[n[t]]}}if(!e||!e.easyXDM){throw new Error("Could not find easyXDM in parent."+h)}return e.easyXDM}function P(t){if(typeof t!="string"||!t){throw new Error("namespace must be a non-empty string")}w("Settings namespace to '"+t+"'");e.easyXDM=d;h=t;if(h){v="easyXDM_"+h.replace(".","_")+"_"}return p}function H(e){if(!e){throw new Error("url is undefined or empty")}return e.match(f)[3]}function B(e){if(!e){throw new Error("url is undefined or empty")}return e.match(f)[4]||""}function j(e){if(!e){throw new Error("url is undefined or empty")}if(/^file/.test(e)){throw new Error("The file:// protocol is not supported")}var t=e.toLowerCase().match(f);var n=t[2],r=t[3],i=t[4]||"";if(n=="http:"&&i==":80"||n=="https:"&&i==":443"){i=""}return n+"//"+r+i}function F(e){if(!e){throw new Error("url is undefined or empty")}e=e.replace(c,"$1/");if(!e.match(/^(http||https):\/\//)){var t=e.substring(0,1)==="/"?"":n.pathname;if(t.substring(t.length-1)!=="/"){t=t.substring(0,t.lastIndexOf("/")+1)}e=n.protocol+"//"+n.host+t+e}while(l.test(e)){e=e.replace(l,"")}w("resolved url '"+e+"'");return e}function I(e,t){if(!t){throw new Error("parameters is undefined or null")}var n="",r=e.indexOf("#");if(r!==-1){n=e.substring(r);e=e.substring(0,r)}var i=[];for(var o in t){if(t.hasOwnProperty(o)){i.push(o+"="+s(t[o]))}}return e+(g?"#":e.indexOf("?")==-1?"?":"&")+i.join("&")+n}function R(e){return typeof e==="undefined"}function z(e,t,n){var r;for(var i in t){if(t.hasOwnProperty(i)){if(i in e){r=t[i];if(typeof r==="object"){z(e[i],r,n)}else if(!n){e[i]=t[i]}}else{e[i]=t[i]}}}return e}function W(){var e=t.body.appendChild(t.createElement("form")),n=e.appendChild(t.createElement("input"));n.name=v+"TEST"+u;m=n!==e.elements[n.name];t.body.removeChild(e);w("HAS_NAME_PROPERTY_BUG: "+m)}function X(e){w("creating frame: "+e.props.src);if(R(m)){W()}var n;if(m){n=t.createElement('<iframe name="'+e.props.name+'"/>')}else{n=t.createElement("IFRAME");n.name=e.props.name}n.id=n.name=e.props.name;delete e.props.name;if(e.onLoad){N(n,"load",e.onLoad)}if(typeof e.container=="string"){e.container=t.getElementById(e.container)}if(!e.container){z(n.style,{position:"absolute",top:"-2000px"});e.container=t.body}var r=e.props.src;delete e.props.src;z(n,e.props);n.border=n.frameBorder=0;n.allowTransparency=true;e.container.appendChild(n);n.src=r;e.props.src=r;return n}function V(e,t){if(typeof e=="string"){e=[e]}var n,r=e.length;while(r--){n=e[r];n=new RegExp(n.substr(0,1)=="^"?n:"^"+n.replace(/(\*)/g,".$1").replace(/\?/g,".")+"$");if(n.test(t)){return true}}return false}function $(r){var i=r.protocol,s;r.isHost=r.isHost||R(q.xdm_p);g=r.hash||false;w("preparing transport stack");if(!r.props){r.props={}}if(!r.isHost){w("using parameters from query");r.channel=q.xdm_c;r.secret=q.xdm_s;r.remote=q.xdm_e;i=q.xdm_p;if(r.acl&&!V(r.acl,r.remote)){throw new Error("Access denied for "+r.remote)}}else{r.remote=F(r.remote);r.channel=r.channel||"default"+u++;r.secret=Math.random().toString(16).substring(2);if(R(i)){if(j(n.href)==j(r.remote)){i="4"}else if(E(e,"postMessage")||E(t,"postMessage")){i="1"}else if(r.swf&&E(e,"ActiveXObject")&&T()){i="6"}else if(navigator.product==="Gecko"&&"frameElement"in e&&navigator.userAgent.indexOf("WebKit")==-1){i="5"}else if(r.remoteHelper){r.remoteHelper=F(r.remoteHelper);i="2"}else{i="0"}w("selecting protocol: "+i)}else{w("using protocol: "+i)}}r.protocol=i;switch(i){case"0":z(r,{interval:100,delay:2e3,useResize:true,useParent:false,usePolling:false},true);if(r.isHost){if(!r.local){w("looking for image to use as local");var o=n.protocol+"//"+n.host,a=t.body.getElementsByTagName("img"),f;var l=a.length;while(l--){f=a[l];if(f.src.substring(0,o.length)===o){r.local=f.src;break}}if(!r.local){w("no image found, defaulting to using the window");r.local=e}}var c={xdm_c:r.channel,xdm_p:0};if(r.local===e){r.usePolling=true;r.useParent=true;r.local=n.protocol+"//"+n.host+n.pathname+n.search;c.xdm_e=r.local;c.xdm_pa=1}else{c.xdm_e=F(r.local)}if(r.container){r.useResize=false;c.xdm_po=1}r.remote=I(r.remote,c)}else{z(r,{channel:q.xdm_c,remote:q.xdm_e,useParent:!R(q.xdm_pa),usePolling:!R(q.xdm_po),useResize:r.useParent?false:r.useResize})}s=[new p.stack.HashTransport(r),new p.stack.ReliableBehavior({}),new p.stack.QueueBehavior({encode:true,maxLength:4e3-r.remote.length}),new p.stack.VerifyBehavior({initiate:r.isHost})];break;case"1":s=[new p.stack.PostMessageTransport(r)];break;case"2":s=[new p.stack.NameTransport(r),new p.stack.QueueBehavior,new p.stack.VerifyBehavior({initiate:r.isHost})];break;case"3":s=[new p.stack.NixTransport(r)];break;case"4":s=[new p.stack.SameOriginTransport(r)];break;case"5":s=[new p.stack.FrameElementTransport(r)];break;case"6":if(!y){T()}s=[new p.stack.FlashTransport(r)];break}s.push(new p.stack.QueueBehavior({lazy:r.lazy,remove:true}));return s}function J(e){var t,n={incoming:function(e,t){this.up.incoming(e,t)},outgoing:function(e,t){this.down.outgoing(e,t)},callback:function(e){this.up.callback(e)},init:function(){this.down.init()},destroy:function(){this.down.destroy()}};for(var r=0,i=e.length;r<i;r++){t=e[r];z(t,n,true);if(r!==0){t.down=e[r-1]}if(r!==i-1){t.up=e[r+1]}}return t}function K(e){if(e.up==null){e.up=e.down=null}else{e.up.down=e.down;e.down.up=e.up;e.up=e.down=null}}var o=this;var u=Math.floor(Math.random()*1e4);var a=Function.prototype;var f=/^((http.?:)\/\/([^:\/\s]+)(:\d+)*)/;var l=/[\-\w]+\/\.\.\//;var c=/([^:])\/\//g;var h="";var p={};var d=e.easyXDM;var v="easyXDM_";var m;var g=false;var y;var b;var w=a;var N,C;if(E(e,"addEventListener")){N=function(e,t,n){w("adding listener "+t);e.addEventListener(t,n,false)};C=function(e,t,n){w("removing listener "+t);e.removeEventListener(t,n,false)}}else if(E(e,"attachEvent")){N=function(e,t,n){w("adding listener "+t);e.attachEvent("on"+t,n)};C=function(e,t,n){w("removing listener "+t);e.detachEvent("on"+t,n)}}else{throw new Error("Browser not supported")}var k=false,L=[],A;if("readyState"in t){A=t.readyState;k=A=="complete"||~navigator.userAgent.indexOf("AppleWebKit/")&&(A=="loaded"||A=="interactive")}else{k=!!t.body}if(!k){if(E(e,"addEventListener")){N(t,"DOMContentLoaded",O)}else{N(t,"readystatechange",function(){if(t.readyState=="complete"){O()}});if(t.documentElement.doScroll&&e===top){var M=function(){if(k){return}try{t.documentElement.doScroll("left")}catch(e){r(M,1);return}O()};M()}}N(e,"load",O)}var q=function(e){e=e.substring(1).split("&");var t={},n,r=e.length;while(r--){n=e[r].split("=");t[n[0]]=i(n[1])}return t}(/xdm_e=/.test(n.search)?n.search:n.hash);var U=function(){var e={};var t={a:[1,2,3]},n='{"a":[1,2,3]}';if(typeof JSON!="undefined"&&typeof JSON.stringify==="function"&&JSON.stringify(t).replace(/\s/g,"")===n){return JSON}if(Object.toJSON){if(Object.toJSON(t).replace(/\s/g,"")===n){e.stringify=Object.toJSON}}if(typeof String.prototype.evalJSON==="function"){t=n.evalJSON();if(t.a&&t.a.length===3&&t.a[2]===3){e.parse=function(e){return e.evalJSON()}}}if(e.stringify&&e.parse){U=function(){return e};return e}return null};z(p,{version:"2.4.15.118",query:q,stack:{},apply:z,getJSONObject:U,whenReady:_,noConflict:P});z(p,{checkAcl:V,getDomainName:H,getLocation:j,appendQueryParameters:I});var Q={_deferred:[],flush:function(){this.trace("... deferred messages ...");for(var e=0,t=this._deferred.length;e<t;e++){this.trace(this._deferred[e])}this._deferred.length=0;this.trace("... end of deferred messages ...")},getTime:function(){var e=new Date,t=e.getHours()+"",n=e.getMinutes()+"",r=e.getSeconds()+"",i=e.getMilliseconds()+"",s="000";if(t.length==1){t="0"+t}if(n.length==1){n="0"+n}if(r.length==1){r="0"+r}i=s.substring(i.length)+i;return t+":"+n+":"+r+"."+i},log:function(t){if(!S(e,"console")||R(console.log)){this.log=a}else{this.log=function(e){console.log(n.host+(h?":"+h:"")+" - "+this.getTime()+": "+e)}}this.log(t)},trace:function(r){if(!k){if(this._deferred.length===0){p.whenReady(Q.flush,Q)}this._deferred.push(r);this.log(r)}else{var i=t.getElementById("log");if(i){this.trace=function(e){try{i.appendChild(t.createElement("div")).appendChild(t.createTextNode(n.host+(h?":"+h:"")+" - "+this.getTime()+":"+e));i.scrollTop=i.scrollHeight}catch(r){}}}else if(S(e,"console")&&!R(console.info)){this.trace=function(e){console.info(n.host+(h?":"+h:"")+" - "+this.getTime()+":"+e)}}else{var s=n.host,o=s.replace(/\[-.:]/g,"")+"easyxdm_log",u;try{u=e.open("",o,"width=800,height=200,status=0,navigation=0,scrollbars=1")}catch(f){}if(u){var l=u.document;i=l.getElementById("log");if(!i){l.write("<html><head><title>easyXDM log "+s+"</title></head>");l.write('<body><div id="log"></div></body></html>');l.close();i=l.getElementById("log")}this.trace=function(e){try{i.appendChild(l.createElement("div")).appendChild(l.createTextNode(n.host+(h?":"+h:"")+" - "+this.getTime()+":"+e));i.scrollTop=i.scrollHeight}catch(t){}};this.trace("---- new logger at "+n.href)}if(!i){this.trace=a}}this.trace(r)}},getTracer:function(e){return function(t){Q.trace(e+": "+t)}}};Q.log("easyXDM present on '"+n.href);p.Debug=Q;w=Q.getTracer("{Private}");p.DomHelper={on:N,un:C,requiresJSON:function(n){if(!S(e,"JSON")){Q.log("loading external JSON");t.write("<"+'script type="text/javascript" src="'+n+'"><'+"/script>")}else{Q.log("native JSON found")}}};(function(){var e={};p.Fn={set:function(t,n){this._trace("storing function "+t);e[t]=n},get:function(t,n){this._trace("retrieving function "+t);var r=e[t];if(!r){this._trace(t+" not found")}if(n){delete e[t]}return r}};p.Fn._trace=Q.getTracer("easyXDM.Fn")})();p.Socket=function(e){var t=Q.getTracer("easyXDM.Socket");t("constructor");var n=J($(e).concat([{incoming:function(t,n){e.onMessage(t,n)},callback:function(t){if(e.onReady){e.onReady(t)}}}])),r=j(e.remote);this.origin=j(e.remote);this.destroy=function(){n.destroy()};this.postMessage=function(e){n.outgoing(e,r)};n.init()};p.Rpc=function(e,t){var n=Q.getTracer("easyXDM.Rpc");n("constructor");if(t.local){for(var r in t.local){if(t.local.hasOwnProperty(r)){var i=t.local[r];if(typeof i==="function"){t.local[r]={method:i}}}}}var s=J($(e).concat([new p.stack.RpcBehavior(this,t),{callback:function(t){if(e.onReady){e.onReady(t)}}}]));this.origin=j(e.remote);this.destroy=function(){s.destroy()};s.init()};p.stack.SameOriginTransport=function(e){var t=Q.getTracer("easyXDM.stack.SameOriginTransport");t("constructor");var i,s,o,u;return i={outgoing:function(e,t,n){o(e);if(n){n()}},destroy:function(){t("destroy");if(s){s.parentNode.removeChild(s);s=null}},onDOMReady:function(){t("init");u=j(e.remote);if(e.isHost){z(e.props,{src:I(e.remote,{xdm_e:n.protocol+"//"+n.host+n.pathname,xdm_c:e.channel,xdm_p:4}),name:v+e.channel+"_provider"});s=X(e);p.Fn.set(e.channel,function(e){o=e;r(function(){i.up.callback(true)},0);return function(e){i.up.incoming(e,u)}})}else{o=D().Fn.get(e.channel,true)(function(e){i.up.incoming(e,u)});r(function(){i.up.callback(true)},0)}},init:function(){_(i.onDOMReady,i)}}};p.stack.FlashTransport=function(e){function d(e,t){r(function(){i("received message");s.up.incoming(e,f)},0)}function m(n){i("creating factory with SWF from "+n);var r=e.swf+"?host="+e.isHost;var s="easyXDM_swf_"+Math.floor(Math.random()*1e4);p.Fn.set("flash_loaded"+n.replace(/[\-.]/g,"_"),function(){p.stack.FlashTransport[n].swf=l=c.firstChild;var e=p.stack.FlashTransport[n].queue;for(var t=0;t<e.length;t++){e[t]()}e.length=0});if(e.swfContainer){c=typeof e.swfContainer=="string"?t.getElementById(e.swfContainer):e.swfContainer}else{c=t.createElement("div");z(c.style,b&&e.swfNoThrottle?{height:"20px",width:"20px",position:"fixed",right:0,top:0}:{height:"1px",width:"1px",position:"absolute",overflow:"hidden",right:0,top:0});t.body.appendChild(c)}var u="callback=flash_loaded"+n.replace(/[\-.]/g,"_")+"&proto="+o.location.protocol+"&domain="+H(o.location.href)+"&port="+B(o.location.href)+"&ns="+h;u+="&log=true";c.innerHTML="<object height='20' width='20' type='application/x-shockwave-flash' id='"+s+"' data='"+r+"'>"+"<param name='allowScriptAccess' value='always'></param>"+"<param name='wmode' value='transparent'>"+"<param name='movie' value='"+r+"'></param>"+"<param name='flashvars' value='"+u+"'></param>"+"<embed type='application/x-shockwave-flash' FlashVars='"+u+"' allowScriptAccess='always' wmode='transparent' src='"+r+"' height='1' width='1'></embed>"+"</object>"}var i=Q.getTracer("easyXDM.stack.FlashTransport");i("constructor");if(!e.swf){throw new Error("Path to easyxdm.swf is missing")}var s,u,a,f,l,c;return s={outgoing:function(t,n,r){l.postMessage(e.channel,t.toString());if(r){r()}},destroy:function(){i("destroy");try{l.destroyChannel(e.channel)}catch(t){}l=null;if(u){u.parentNode.removeChild(u);u=null}},onDOMReady:function(){i("init");f=e.remote;p.Fn.set("flash_"+e.channel+"_init",function(){r(function(){i("firing onReady");s.up.callback(true)})});p.Fn.set("flash_"+e.channel+"_onMessage",d);e.swf=F(e.swf);var t=H(e.swf);var o=function(){p.stack.FlashTransport[t].init=true;l=p.stack.FlashTransport[t].swf;l.createChannel(e.channel,e.secret,j(e.remote),e.isHost);if(e.isHost){if(b&&e.swfNoThrottle){z(e.props,{position:"fixed",right:0,top:0,height:"20px",width:"20px"})}z(e.props,{src:I(e.remote,{xdm_e:j(n.href),xdm_c:e.channel,xdm_p:6,xdm_s:e.secret}),name:v+e.channel+"_provider"});u=X(e)}};if(p.stack.FlashTransport[t]&&p.stack.FlashTransport[t].init){o()}else{if(!p.stack.FlashTransport[t]){p.stack.FlashTransport[t]={queue:[o]};m(t)}else{p.stack.FlashTransport[t].queue.push(o)}}},init:function(){_(s.onDOMReady,s)}}};p.stack.PostMessageTransport=function(t){function f(e){if(e.origin){return j(e.origin)}if(e.uri){return j(e.uri)}if(e.domain){return n.protocol+"//"+e.domain}throw"Unable to retrieve the origin of the event"}function l(e){var n=f(e);i("received message '"+e.data+"' from "+n);if(n==a&&e.data.substring(0,t.channel.length+1)==t.channel+" "){s.up.incoming(e.data.substring(t.channel.length+1),n)}}var i=Q.getTracer("easyXDM.stack.PostMessageTransport");i("constructor");var s,o,u,a;return s={outgoing:function(e,n,r){u.postMessage(t.channel+" "+e,n||a);if(r){r()}},destroy:function(){i("destroy");C(e,"message",l);if(o){u=null;o.parentNode.removeChild(o);o=null}},onDOMReady:function(){i("init");a=j(t.remote);if(t.isHost){var f=function(n){if(n.data==t.channel+"-ready"){i("firing onReady");u="postMessage"in o.contentWindow?o.contentWindow:o.contentWindow.document;C(e,"message",f);N(e,"message",l);r(function(){s.up.callback(true)},0)}};N(e,"message",f);z(t.props,{src:I(t.remote,{xdm_e:j(n.href),xdm_c:t.channel,xdm_p:1}),name:v+t.channel+"_provider"});o=X(t)}else{N(e,"message",l);u="postMessage"in e.parent?e.parent:e.parent.document;u.postMessage(t.channel+"-ready",a);r(function(){s.up.callback(true)},0)}},init:function(){_(s.onDOMReady,s)}}};p.stack.FrameElementTransport=function(i){var s=Q.getTracer("easyXDM.stack.FrameElementTransport");s("constructor");var o,u,a,f;return o={outgoing:function(e,t,n){a.call(this,e);if(n){n()}},destroy:function(){s("destroy");if(u){u.parentNode.removeChild(u);u=null}},onDOMReady:function(){s("init");f=j(i.remote);if(i.isHost){z(i.props,{src:I(i.remote,{xdm_e:j(n.href),xdm_c:i.channel,xdm_p:5}),name:v+i.channel+"_provider"});u=X(i);u.fn=function(e){delete u.fn;a=e;r(function(){o.up.callback(true)},0);return function(e){o.up.incoming(e,f)}}}else{if(t.referrer&&j(t.referrer)!=q.xdm_e){e.top.location=q.xdm_e}a=e.frameElement.fn(function(e){o.up.incoming(e,f)});o.up.callback(true)}},init:function(){_(o.onDOMReady,o)}}};p.stack.NameTransport=function(e){function c(n){var r=e.remoteHelper+(i?"#_3":"#_2")+e.channel;t("sending message "+n);t("navigating to  '"+r+"'");s.contentWindow.sendMessage(n,r)}function h(){if(i){if(++u===2||!i){n.up.callback(true)}}else{c("ready");t("calling onReady");n.up.callback(true)}}function d(e){t("received message "+e);n.up.incoming(e,f)}function m(){if(a){r(function(){a(true)},0)}}var t=Q.getTracer("easyXDM.stack.NameTransport");t("constructor");if(e.isHost&&R(e.remoteHelper)){t("missing remoteHelper");throw new Error("missing remoteHelper")}var n;var i,s,o,u,a,f,l;return n={outgoing:function(e,t,n){a=n;c(e)},destroy:function(){t("destroy");s.parentNode.removeChild(s);s=null;if(i){o.parentNode.removeChild(o);o=null}},onDOMReady:function(){t("init");i=e.isHost;u=0;f=j(e.remote);e.local=F(e.local);if(i){p.Fn.set(e.channel,function(n){t("received initial message "+n);if(i&&n==="ready"){p.Fn.set(e.channel,d);h()}});l=I(e.remote,{xdm_e:e.local,xdm_c:e.channel,xdm_p:2});z(e.props,{src:l+"#"+e.channel,name:v+e.channel+"_provider"});o=X(e)}else{e.remoteHelper=e.remote;p.Fn.set(e.channel,d)}s=X({props:{src:e.local+"#_4"+e.channel},onLoad:function n(){var t=s||this;C(t,"load",n);p.Fn.set(e.channel+"_load",m);(function i(){if(typeof t.contentWindow.sendMessage=="function"){h()}else{r(i,50)}})()}})},init:function(){_(n.onDOMReady,n)}}};p.stack.HashTransport=function(t){function m(e){n("sending message '"+(l+1)+" "+e+"' to "+d);if(!h){n("no caller window");return}var r=t.remote+"#"+l++ +"_"+e;(o||!p?h.contentWindow:h).location=r}function g(e){f=e;n("received message '"+f+"' from "+d);i.up.incoming(f.substring(f.indexOf("_")+1),d)}function y(){if(!c){return}var e=c.location.href,t="",r=e.indexOf("#");if(r!=-1){t=e.substring(r)}if(t&&t!=f){n("poll: new message");g(t)}}function b(){n("starting polling");u=setInterval(y,a)}var n=Q.getTracer("easyXDM.stack.HashTransport");n("constructor");var i;var s=this,o,u,a,f,l,c,h;var p,d;return i={outgoing:function(e,t){m(e)},destroy:function(){e.clearInterval(u);if(o||!p){h.parentNode.removeChild(h)}h=null},onDOMReady:function(){o=t.isHost;a=t.interval;f="#"+t.channel;l=0;p=t.useParent;d=j(t.remote);if(o){t.props={src:t.remote,name:v+t.channel+"_provider"};if(p){t.onLoad=function(){c=e;b();i.up.callback(true)}}else{var s=0,u=t.delay/50;(function m(){if(++s>u){n("unable to get reference to _listenerWindow, giving up");throw new Error("Unable to reference listenerwindow")}try{c=h.contentWindow.frames[v+t.channel+"_consumer"]}catch(e){}if(c){b();n("got a reference to _listenerWindow");i.up.callback(true)}else{r(m,50)}})()}h=X(t)}else{c=e;b();if(p){h=parent;i.up.callback(true)}else{z(t,{props:{src:t.remote+"#"+t.channel+new Date,name:v+t.channel+"_consumer"},onLoad:function(){i.up.callback(true)}});h=X(t)}}},init:function(){_(i.onDOMReady,i)}}};p.stack.ReliableBehavior=function(e){var t=Q.getTracer("easyXDM.stack.ReliableBehavior");t("constructor");var n,r;var i=0,s=0,o="";return n={incoming:function(e,u){t("incoming: "+e);var a=e.indexOf("_"),f=e.substring(0,a).split(",");e=e.substring(a+1);if(f[0]==i){t("message delivered");o="";if(r){r(true)}}if(e.length>0){t("sending ack, and passing on "+e);n.down.outgoing(f[1]+","+i+"_"+o,u);if(s!=f[1]){s=f[1];n.up.incoming(e,u)}}},outgoing:function(e,t,u){o=e;r=u;n.down.outgoing(s+","+ ++i+"_"+e,t)}}};p.stack.QueueBehavior=function(e){function p(){if(e.remove&&o.length===0){t("removing myself from the stack");K(n);return}if(u||o.length===0||f){return}t("dispatching from queue");u=true;var i=o.shift();n.down.outgoing(i.data,i.origin,function(e){u=false;if(i.callback){r(function(){i.callback(e)},0)}p()})}var t=Q.getTracer("easyXDM.stack.QueueBehavior");t("constructor");var n,o=[],u=true,a="",f,l=0,c=false,h=false;return n={init:function(){if(R(e)){e={}}if(e.maxLength){l=e.maxLength;h=true}if(e.lazy){c=true}else{n.down.init()}},callback:function(e){u=false;var t=n.up;p();t.callback(e)},incoming:function(r,s){if(h){var o=r.indexOf("_"),u=parseInt(r.substring(0,o),10);a+=r.substring(o+1);if(u===0){t("received the last fragment");if(e.encode){a=i(a)}n.up.incoming(a,s);a=""}else{t("waiting for more fragments, seq="+r)}}else{n.up.incoming(r,s)}},outgoing:function(r,i,u){if(e.encode){r=s(r)}var a=[],f;if(h){while(r.length!==0){f=r.substring(0,l);r=r.substring(f.length);a.push(f)}while(f=a.shift()){t("enqueuing");o.push({data:a.length+"_"+f,origin:i,callback:a.length===0?u:null})}}else{o.push({data:r,origin:i,callback:u})}if(c){n.down.init()}else{p()}},destroy:function(){t("destroy");f=true;n.down.destroy()}}};p.stack.VerifyBehavior=function(e){function o(){t("requesting verification");r=Math.random().toString(16).substring(2);n.down.outgoing(r)}var t=Q.getTracer("easyXDM.stack.VerifyBehavior");t("constructor");if(R(e.initiate)){throw new Error("settings.initiate is not set")}var n,r,i,s=false;return n={incoming:function(s,u){var a=s.indexOf("_");if(a===-1){if(s===r){t("verified, calling callback");n.up.callback(true)}else if(!i){t("returning secret");i=s;if(!e.initiate){o()}n.down.outgoing(s)}}else{if(s.substring(0,a)===i){n.up.incoming(s.substring(a+1),u)}}},outgoing:function(e,t,i){n.down.outgoing(r+"_"+e,t,i)},callback:function(t){if(e.initiate){o()}}}};p.stack.RpcBehavior=function(e,t){function u(e){e.jsonrpc="2.0";r.down.outgoing(i.stringify(e))}function f(e,t){var r=Array.prototype.slice;n("creating method "+t);return function(){n("executing method "+t);var i=arguments.length,a,f={method:t};if(i>0&&typeof arguments[i-1]==="function"){if(i>1&&typeof arguments[i-2]==="function"){a={success:arguments[i-2],error:arguments[i-1]};f.params=r.call(arguments,0,i-2)}else{a={success:arguments[i-1]};f.params=r.call(arguments,0,i-1)}o[""+ ++s]=a;f.id=s}else{f.params=r.call(arguments,0)}if(e.namedParams&&f.params.length===1){f.params=f.params[0]}u(f)}}function l(e,t,r,i){if(!r){n("requested to execute non-existent procedure "+e);if(t){u({id:t,error:{code:-32601,message:"Procedure not found."}})}return}n("requested to execute procedure "+e);var s,o;if(t){s=function(e){s=a;u({id:t,result:e})};o=function(e,n){o=a;var r={id:t,error:{code:-32099,message:e}};if(n){r.error.data=n}u(r)}}else{s=o=a}if(!x(i)){i=[i]}try{var f=r.method.apply(r.scope,i.concat([s,o]));if(!R(f)){s(f)}}catch(l){o(l.message)}}var n=Q.getTracer("easyXDM.stack.RpcBehavior");var r,i=t.serializer||U();var s=0,o={};return r={incoming:function(e,r){var s=i.parse(e);if(s.method){n("received request to execute method "+s.method+(s.id?" using callback id "+s.id:""));if(t.handle){t.handle(s,u)}else{l(s.method,s.id,t.local[s.method],s.params)}}else{n("received return value destined to callback with id "+s.id);var a=o[s.id];if(s.error){if(a.error){a.error(s.error)}else{n("unhandled error returned.")}}else if(a.success){a.success(s.result)}delete o[s.id]}},init:function(){n("init");if(t.remote){n("creating stubs");for(var i in t.remote){if(t.remote.hasOwnProperty(i)){e[i]=f(t.remote[i],i)}}}r.down.init()},destroy:function(){n("destroy");for(var i in t.remote){if(t.remote.hasOwnProperty(i)&&e.hasOwnProperty(i)){delete e[i]}}r.down.destroy()}}};o.easyXDM=p})(window,document,location,window.setTimeout,decodeURIComponent,encodeURIComponent)
// Carga de las librerias para evitar crossdomain en IE7
/*json2.js*/
if(!this.JSON){this.JSON={}}(function(){function f(e){return e<10?"0"+e:e}function quote(e){escapable.lastIndex=0;return escapable.test(e)?'"'+e.replace(escapable,function(e){var t=meta[e];return typeof t==="string"?t:"\\u"+("0000"+e.charCodeAt(0).toString(16)).slice(-4)})+'"':'"'+e+'"'}function str(e,t){var n,r,i,s,o=gap,u,a=t[e];if(a&&typeof a==="object"&&typeof a.toJSON==="function"){a=a.toJSON(e)}if(typeof rep==="function"){a=rep.call(t,e,a)}switch(typeof a){case"string":return quote(a);case"number":return isFinite(a)?String(a):"null";case"boolean":case"null":return String(a);case"object":if(!a){return"null"}gap+=indent;u=[];if(Object.prototype.toString.apply(a)==="[object Array]"){s=a.length;for(n=0;n<s;n+=1){u[n]=str(n,a)||"null"}i=u.length===0?"[]":gap?"[\n"+gap+u.join(",\n"+gap)+"\n"+o+"]":"["+u.join(",")+"]";gap=o;return i}if(rep&&typeof rep==="object"){s=rep.length;for(n=0;n<s;n+=1){r=rep[n];if(typeof r==="string"){i=str(r,a);if(i){u.push(quote(r)+(gap?": ":":")+i)}}}}else{for(r in a){if(Object.hasOwnProperty.call(a,r)){i=str(r,a);if(i){u.push(quote(r)+(gap?": ":":")+i)}}}}i=u.length===0?"{}":gap?"{\n"+gap+u.join(",\n"+gap)+"\n"+o+"}":"{"+u.join(",")+"}";gap=o;return i}}if(typeof Date.prototype.toJSON!=="function"){Date.prototype.toJSON=function(e){return isFinite(this.valueOf())?this.getUTCFullYear()+"-"+f(this.getUTCMonth()+1)+"-"+f(this.getUTCDate())+"T"+f(this.getUTCHours())+":"+f(this.getUTCMinutes())+":"+f(this.getUTCSeconds())+"Z":null};String.prototype.toJSON=Number.prototype.toJSON=Boolean.prototype.toJSON=function(e){return this.valueOf()}}var cx=/[\u0000\u00ad\u0600-\u0604\u070f\u17b4\u17b5\u200c-\u200f\u2028-\u202f\u2060-\u206f\ufeff\ufff0-\uffff]/g,escapable=/[\\\"\x00-\x1f\x7f-\x9f\u00ad\u0600-\u0604\u070f\u17b4\u17b5\u200c-\u200f\u2028-\u202f\u2060-\u206f\ufeff\ufff0-\uffff]/g,gap,indent,meta={"\b":"\\b","	":"\\t","\n":"\\n","\f":"\\f","\r":"\\r",'"':'\\"',"\\":"\\\\"},rep;if(typeof JSON.stringify!=="function"){JSON.stringify=function(e,t,n){var r;gap="";indent="";if(typeof n==="number"){for(r=0;r<n;r+=1){indent+=" "}}else if(typeof n==="string"){indent=n}rep=t;if(t&&typeof t!=="function"&&(typeof t!=="object"||typeof t.length!=="number")){throw new Error("JSON.stringify")}return str("",{"":e})}}if(typeof JSON.parse!=="function"){JSON.parse=function(text,reviver){function walk(e,t){var n,r,i=e[t];if(i&&typeof i==="object"){for(n in i){if(Object.hasOwnProperty.call(i,n)){r=walk(i,n);if(r!==undefined){i[n]=r}else{delete i[n]}}}}return reviver.call(e,t,i)}var j;text=String(text);cx.lastIndex=0;if(cx.test(text)){text=text.replace(cx,function(e){return"\\u"+("0000"+e.charCodeAt(0).toString(16)).slice(-4)})}if(/^[\],:{}\s]*$/.test(text.replace(/\\(?:["\\\/bfnrt]|u[0-9a-fA-F]{4})/g,"@").replace(/"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g,"]").replace(/(?:^|:|,)(?:\s*\[)+/g,""))){j=eval("("+text+")");return typeof reviver==="function"?walk({"":j},""):j}throw new SyntaxError("JSON.parse")}}})()
// Carga de LazyLoad (libreria de carga de imagenes solo de la zona visible de la web)
/*lazyload*/ 
if(!window.lzld){
(function(e,t){function l(e){if(N(e,s)===-1){if(u){S()}g(e,s.push(e)-1)}}function c(){var e=t.getElementsByTagName("img"),n;for(var i=0,o=e.length;i<o;i+=1){n=e[i];if(n.getAttribute(r)&&N(n,s)===-1){s.push(n)}}w();setTimeout(f,25)}function h(){o=true;f();setTimeout(f,25)}function p(e,t){var n=0;return function(){var r=+(new Date);if(r-n<t){return}n=r;e.apply(this,arguments)}}function d(e,t,n){if(e.attachEvent){e.attachEvent&&e.attachEvent("on"+t,n)}else{e.addEventListener(t,n,false)}}function v(e,t,n){if(e.detachEvent){e.detachEvent&&e.detachEvent("on"+t,n)}else{e.removeEventListener(t,n,false)}}function m(n){function s(i){if(i.type==="readystatechange"&&t.readyState!=="complete"){return}v(i.type==="load"?e:t,i.type,s);if(!r){r=true;n()}}function o(){try{t.documentElement.doScroll("left")}catch(e){setTimeout(o,50);return}s("poll")}var r=false,i=true;if(t.readyState==="complete"){n()}else{if(t.createEventObject&&t.documentElement.doScroll){try{i=!e.frameElement}catch(u){}if(i){o()}}d(t,"DOMContentLoaded",s);d(t,"readystatechange",s);d(e,"load",s)}}function g(e,o){if(T(t.documentElement,e)&&e.getBoundingClientRect().top<i+n){e.onload=null;e.removeAttribute("onload");e.onerror=null;e.removeAttribute("onerror");e.src=e.getAttribute(r);e.removeAttribute(r);s[o]=null;return true}else{return false}}function y(){if(t.documentElement.clientHeight>=0){return t.documentElement.clientHeight}else{if(t.body&&t.body.clientHeight>=0){return t.body.clientHeight}else{if(e.innerHeight>=0){return e.innerHeight}else{return 0}}}}function b(){i=y()}function w(){var e=s.length,t,n=true;for(t=0;t<e;t++){var r=s[t];if(r!==null&&!g(r,t)){n=false}}if(n&&o){E()}}function E(){u=true;v(e,"resize",a);v(e,"resize",f);v(e,"scroll",f);v(e,"load",h)}function S(){u=false;d(e,"resize",a);d(e,"resize",f);d(e,"scroll",f)}function x(){var e=HTMLImageElement.prototype.getAttribute;HTMLImageElement.prototype.getAttribute=function(t){if(t==="src"){var n=e.call(this,r);return n||e.call(this,t)}else{return e.call(this,t)}}}function N(e,t,n){var r;if(t){if(Array.prototype.indexOf){return Array.prototype.indexOf.call(t,e,n)}r=t.length;n=n?n<0?Math.max(0,r+n):n:0;for(;n<r;n++){if(n in t&&t[n]===e){return n}}}return-1}var n=200,r="data-src",i=y(),s=[],o=false,u=false,a=p(b,20),f=p(w,20);e.HTMLImageElement&&x();e.lzld=l;m(c);d(e,"load",h);S();var T=t.documentElement.compareDocumentPosition?function(e,t){return!!(e.compareDocumentPosition(t)&16)}:t.documentElement.contains?function(e,t){return e!==t&&(e.contains?e.contains(t):false)}:function(e,t){while(t=t.parentNode){if(t===e){return true}}return false}})(this,document)
}
// Carga de SWFObject (libreria de inclusion de objetos flash en html)
if (!SWFObject) {
if(typeof deconcept=="undefined"){var deconcept=new Object();}if(typeof deconcept.util=="undefined"){deconcept.util=new Object();}if(typeof deconcept.SWFObjectUtil=="undefined"){deconcept.SWFObjectUtil=new Object();}deconcept.SWFObject=function(_1,id,w,h,_5,c,_7,_8,_9,_a){if(!document.getElementById){return;}this.DETECT_KEY=_a?_a:"detectflash";this.skipDetect=deconcept.util.getRequestParameter(this.DETECT_KEY);this.params=new Object();this.variables=new Object();this.attributes=new Array();if(_1){this.setAttribute("swf",_1);}if(id){this.setAttribute("id",id);}if(w){this.setAttribute("width",w);}if(h){this.setAttribute("height",h);}if(_5){this.setAttribute("version",new deconcept.PlayerVersion(_5.toString().split(".")));}this.installedVer=deconcept.SWFObjectUtil.getPlayerVersion();if(!window.opera&&document.all&&this.installedVer.major>7){deconcept.SWFObject.doPrepUnload=true;}if(c){this.addParam("bgcolor",c);}var q=_7?_7:"high";this.addParam("quality",q);this.setAttribute("useExpressInstall",false);this.setAttribute("doExpressInstall",false);var _c=(_8)?_8:window.location;this.setAttribute("xiRedirectUrl",_c);this.setAttribute("redirectUrl","");if(_9){this.setAttribute("redirectUrl",_9);}};deconcept.SWFObject.prototype={useExpr:function(_d){this.xiSWFPath=!_d?"expressinstall.swf":_d;this.setAttribute("useExpressInstall",true);},setAttribute:function(_e,_f){this.attributes[_e]=_f;},getAttribute:function(_10){return this.attributes[_10];},addParam:function(_11,_12){this.params[_11]=_12;},getParams:function(){return this.params;},addVariable:function(_13,_14){this.variables[_13]=_14;},getVariable:function(_15){return this.variables[_15];},getVariables:function(){return this.variables;},getVariablePairs:function(){var _16=new Array();var key;var _18=this.getVariables();for(key in _18){_16[_16.length]=key+"="+_18[key];}return _16;},getSWFHTML:function(){var _19="";if(navigator.plugins&&navigator.mimeTypes&&navigator.mimeTypes.length){if(this.getAttribute("doExpressInstall")){this.addVariable("MMplayerType","PlugIn");this.setAttribute("swf",this.xiSWFPath);}_19="<embed type=\"application/x-shockwave-flash\" src=\""+this.getAttribute("swf")+"\" width=\""+this.getAttribute("width")+"\" height=\""+this.getAttribute("height")+"\" style=\""+this.getAttribute("style")+"\"";_19+=" id=\""+this.getAttribute("id")+"\" name=\""+this.getAttribute("id")+"\" ";var _1a=this.getParams();for(var key in _1a){_19+=[key]+"=\""+_1a[key]+"\" ";}var _1c=this.getVariablePairs().join("&");if(_1c.length>0){_19+="flashvars=\""+_1c+"\"";}_19+="/>";}else{if(this.getAttribute("doExpressInstall")){this.addVariable("MMplayerType","ActiveX");this.setAttribute("swf",this.xiSWFPath);}_19="<object id=\""+this.getAttribute("id")+"\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" width=\""+this.getAttribute("width")+"\" height=\""+this.getAttribute("height")+"\" style=\""+this.getAttribute("style")+"\">";_19+="<param name=\"movie\" value=\""+this.getAttribute("swf")+"\" />";var _1d=this.getParams();for(var key in _1d){_19+="<param name=\""+key+"\" value=\""+_1d[key]+"\" />";}var _1f=this.getVariablePairs().join("&");if(_1f.length>0){_19+="<param name=\"flashvars\" value=\""+_1f+"\" />";}_19+="</object>";}return _19;},write:function(_20){if(this.getAttribute("useExpressInstall")){var _21=new deconcept.PlayerVersion([6,0,65]);if(this.installedVer.versionIsValid(_21)&&!this.installedVer.versionIsValid(this.getAttribute("version"))){this.setAttribute("doExpressInstall",true);this.addVariable("MMredirectURL",escape(this.getAttribute("xiRedirectUrl")));document.title=document.title.slice(0,47)+" - Flash Player Installation";this.addVariable("MMdoctitle",document.title);}}if(this.skipDetect||this.getAttribute("doExpressInstall")||this.installedVer.versionIsValid(this.getAttribute("version"))){var n=(typeof _20=="string")?document.getElementById(_20):_20;n.innerHTML=this.getSWFHTML();return true;}else{if(this.getAttribute("redirectUrl")!=""){document.location.replace(this.getAttribute("redirectUrl"));}}return false;}};deconcept.SWFObjectUtil.getPlayerVersion=function(){var _23=new deconcept.PlayerVersion([0,0,0]);if(navigator.plugins&&navigator.mimeTypes.length){var x=navigator.plugins["Shockwave Flash"];if(x&&x.description){_23=new deconcept.PlayerVersion(x.description.replace(/([a-zA-Z]|\s)+/,"").replace(/(\s+r|\s+b[0-9]+)/,".").split("."));}}else{if(navigator.userAgent&&navigator.userAgent.indexOf("Windows CE")>=0){var axo=1;var _26=3;while(axo){try{_26++;axo=new ActiveXObject("ShockwaveFlash.ShockwaveFlash."+_26);_23=new deconcept.PlayerVersion([_26,0,0]);}catch(e){axo=null;}}}else{try{var axo=new ActiveXObject("ShockwaveFlash.ShockwaveFlash.7");}catch(e){try{var axo=new ActiveXObject("ShockwaveFlash.ShockwaveFlash.6");_23=new deconcept.PlayerVersion([6,0,21]);axo.AllowScriptAccess="always";}catch(e){if(_23.major==6){return _23;}}try{axo=new ActiveXObject("ShockwaveFlash.ShockwaveFlash");}catch(e){}}if(axo!=null){_23=new deconcept.PlayerVersion(axo.GetVariable("$version").split(" ")[1].split(","));}}}return _23;};deconcept.PlayerVersion=function(_29){this.major=_29[0]!=null?parseInt(_29[0]):0;this.minor=_29[1]!=null?parseInt(_29[1]):0;this.rev=_29[2]!=null?parseInt(_29[2]):0;};deconcept.PlayerVersion.prototype.versionIsValid=function(fv){if(this.major<fv.major){return false;}if(this.major>fv.major){return true;}if(this.minor<fv.minor){return false;}if(this.minor>fv.minor){return true;}if(this.rev<fv.rev){return false;}return true;};deconcept.util={getRequestParameter:function(_2b){var q=document.location.search||document.location.hash;if(_2b==null){return q;}if(q){var _2d=q.substring(1).split("&");for(var i=0;i<_2d.length;i++){if(_2d[i].substring(0,_2d[i].indexOf("="))==_2b){return _2d[i].substring((_2d[i].indexOf("=")+1));}}}return "";}};deconcept.SWFObjectUtil.cleanupSWFs=function(){var _2f=document.getElementsByTagName("OBJECT");for(var i=_2f.length-1;i>=0;i--){_2f[i].style.display="none";for(var x in _2f[i]){if(typeof _2f[i][x]=="function"){_2f[i][x]=function(){};}}}};if(deconcept.SWFObject.doPrepUnload){if(!deconcept.unloadSet){deconcept.SWFObjectUtil.prepUnload=function(){__flash_unloadHandler=function(){};__flash_savedUnloadHandler=function(){};window.attachEvent("onunload",deconcept.SWFObjectUtil.cleanupSWFs);};window.attachEvent("onbeforeunload",deconcept.SWFObjectUtil.prepUnload);deconcept.unloadSet=true;}}if(!document.getElementById&&document.all){document.getElementById=function(id){return document.all[id];};}var getQueryParamValue=deconcept.util.getRequestParameter;var FlashObject=deconcept.SWFObject;var SWFObject=deconcept.SWFObject;
}
//Carga de version de jquery que soporte crossdomain
var jQuery_1_8_1 = null;

if (typeof jQuery == 'undefined') {
	function getScript(url, success) {
		var script	= document.createElement('script');
	    script.src = url;
		var head = document.getElementsByTagName('head')[0],
			done = false;
			// Attach handlers for all browsers
			script.onload = script.onreadystatechange = function() {
				if (!done && (!this.readyState || this.readyState == 'loaded' || this.readyState == 'complete')) {
					done = true;
					// callback function provided as param
					success();
					script.onload = script.onreadystatechange = null;
					head.removeChild(script);
			};
		};
		head.appendChild(script);
	};
	
	getScript('http://nets.abc.es/jquery/1.3.2/jquery.min.js', function() {
		if (typeof jQuery=='undefined') {
			// No se ha cargado la libreria
		} else {
			jQuery.ajaxSetup({
				cache: true
			});
			if((typeof jQuery_1_8_1 == "undefined") ||  (jQuery_1_8_1 == null)){
				//jQuery.getScript('http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js', function() {
				jQuery.getScript('http://nets.abc.es/jquery/1.8.1/jquery.min.js', function() {
			    	jQuery_1_8_1 = jQuery.noConflict(true);
			    });
			}
		}
	});
}else{ // jQuery ya ha sido cargado
	jQuery.ajaxSetup({
		cache: true
	});
	if((typeof jQuery_1_8_1 == "undefined") ||  (jQuery_1_8_1 == null)){
		//jQuery.getScript('http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js', function() {
		jQuery.getScript('http://nets.abc.es/jquery/1.8.1/jquery.min.js', function() {
			jQuery_1_8_1 = jQuery.noConflict(true);
		});
	}
};

/*NEW PLAYER*/
var htmlSupport = false;
/*NEW PLAYER*/

/**********************************************************************************************************************/
/****************************************** MOBILE BROWSER DETECTION CODE *********************************************/
/**********************************************************************************************************************/
var uagent = navigator.userAgent.toLowerCase();
var contavid=1;
var relidGlobal = '';

// JavaScript Document
// Web: www.hand-interactive.com
// 
// License info: http://creativecommons.org/licenses/by/3.0/us/

//Initialize some initial string variables we'll look for later.
var deviceIphone = "iphone";
var deviceIPad = "ipad";
var deviceIpod = "ipod";
var devicePlaystation = "playstation";
var deviceWap = "wap";

var deviceWinMob = "windows ce";
var enginePie = "wm5 pie";
var deviceIeMob = "iemobile";

var deviceS60 = "series60";
var deviceSymbian = "symbian";
var deviceS60 = "series60";
var deviceS70 = "series70";
var deviceS80 = "series80";
var deviceS90 = "series90";

var deviceBB = "blackberry";

var deviceAndroid = "android";
var motorollaDroid = " droid ";

var deviceMidp = "midp";
var deviceWml = "wml";
var deviceBrew = "brew";

var devicePalm = "palm";
var engineXiino = "xiino";
var engineBlazer = "blazer"; //Old Palm

var devicePda = "pda";
var deviceNintendoDs = "nitro";

var engineWebKit = "webkit";
var engineNetfront = "netfront";


var manuSonyEricsson = "sonyericsson";
var manuericsson = "ericsson";
var manuSamsung1 = "sec-sgh";

var svcDocomo = "docomo";
var svcKddi = "kddi";
var svcVodafone = "vodafone";

//Due to the flexibility of the S60 OSSO Browser, 
//   you may wish to let new S60 devices get the regular pages instead.
var s60GetsMobile = true;

//Due to the flexibility of the iPhone/iPod Touch Browser, 
//   you may wish to let new S60 devices get the regular pages instead.
var iphoneIpodGetsMobile = true;

var origenVideo = "bc";
var externoIdVideo;
var externoIdWidth;
var externoIdHeight;

//**************************
// Detects if the current device is an iPhone.
function DetectIphone()
{
   if (uagent.search(deviceIphone) > -1)
   {
      //The iPod touch says it's an iPhone! So let's disambiguate.
      if (uagent.search(deviceIpod) > -1)
         return false;
      else 
         return true;
   }
   else
      return false;
}

//**************************
// Detects if the current device is an iPhone.
function DetectIPad()
{
    if (uagent.search(deviceIPad) > -1) {
	return true;       
   }
    else {
      return false;
    }
}

//**************************
// Detects if the current device is an iPod Touch.
function DetectIpod()
{
   if (uagent.search(deviceIpod) > -1)
      return true;
   else
      return false;
}

//**************************
// Detects if the current device is an iPhone or iPod Touch.
function DetectIphoneOrIpodOrIPad()
{
   //We repeat the searches here because some iPods 
   //  may report themselves as an iPhone, which is ok.
   if (uagent.search(deviceIphone) > -1 ||
       uagent.search(deviceIpod) > -1 ||
       uagent.search(deviceIPad) > -1)

       return true;
    else
       return false;
}

//**************************
// Detects if the current device is an Android OS-based device.
function DetectAndroid()
{
   if (uagent.search(deviceAndroid) > -1)
      return true;
   else
      return false;
}

function DetectMotorollaDroid()
{
	if (uagent.search(motorollaDroid) > -1)
		return true;
	else
		return false;
}

//**************************
// Detects if the current device is an Android OS-based device and
//   the browser is based on WebKit.
function DetectAndroidWebKit()
{
   if (DetectAndroid())
   {
     if (DetectWebkit())
        return true;
     else
        return false;
   }
   else
      return false;
}

//**************************
// Detects if the current browser is based on WebKit.
function DetectWebkit()
{
   if (uagent.search(engineWebKit) > -1)
      return true;
   else
      return false;
}

//**************************
// Detects if the current browser is the Nokia S60 Open Source Browser.
function DetectS60OssBrowser()
{
   if (DetectWebkit())
   {
     if ((uagent.search(deviceS60) > -1 || 
          uagent.search(deviceSymbian) > -1))
        return true;
     else
        return false;
   }
   else
      return false;
}

//**************************
// Detects if the current device is any Symbian OS-based device,
//   including older S60, Series 70, Series 80, Series 90, and UIQ, 
//   or other browsers running on these devices.
function DetectSymbianOS()
{
   if (uagent.search(deviceSymbian) > -1 ||
       uagent.search(deviceS60) > -1 ||
       uagent.search(deviceS70) > -1 ||
       uagent.search(deviceS80) > -1 ||
       uagent.search(deviceS90) > -1)
      return true;
   else
      return false;
}


//**************************
// Detects if the current browser is a BlackBerry of some sort.
function DetectBlackBerry()
{
   if (uagent.search(deviceBB) > -1)
      return true;
   else
      return false;
}

//**************************
// Detects if the current browser is a Windows Mobile device.
function DetectWindowsMobile()
{
   //Most devices use 'Windows CE', but some report 'iemobile' 
   //  and some older ones report as 'PIE' for Pocket IE. 
   if (uagent.search(deviceWinMob) > -1 ||
       uagent.search(deviceIeMob) > -1 ||
       uagent.search(enginePie) > -1)
      return true;
   else
      return false;
}

//**************************
// Detects if the current browser is on a PalmOS device.
function DetectPalmOS()
{
   //Most devices nowadays report as 'Palm', 
   //  but some older ones reported as Blazer or Xiino.
   if (uagent.search(devicePalm) > -1 ||
       uagent.search(engineBlazer) > -1 ||
       uagent.search(engineXiino) > -1)
      return true;
   else
      return false;
}

//**************************
// Sets whether S60 devices running the 
//   Open Source Browser (based on WebKit)
//   should be detected as 'mobile' or not.
//   Set TRUE to be detected as mobile.
//   Set FALSE and it will not be detected as mobile.
function SetS60GetsMobile(setMobile)
{
   s60GetsMobile = setMobile;
};

//**************************
// Sets whether iPhone/iPod Touch devices running the 
//   Open Source Browser (based on WebKit)
//   should be detected as 'mobile' or not.
//   Set TRUE to be detected as mobile.
//   Set FALSE and it will not be detected as mobile.
function SetS60GetsMobile(setMobile)
{
   iphoneIpodGetsMobile = setMobile;
};


//**************************
// Check to see whether the device is a 'smartphone'.
//   You might wish to send smartphones to a more capable web page
//   than a dumbed down WAP page. 
function DetectSmartphone()
{
   //First, look for iPhone and iPod Touch.
   if (DetectIphoneOrIpodOrIPad())
      return true;

   if (DetectAndroid())
      return true;
		
   //Now, look for S60 Open Source Browser on S60 release 3 devices.
   if (DetectS60OssBrowser())
      return true;

   //Check for other Symbian devices - older S60, UIQ, other.
   if (DetectSymbianOS())
      return true;

   //Check for Windows Mobile devices.
   if (DetectWindowsMobile())
      return true;

   //Next, look for a BlackBerry
   if (DetectBlackBerry())
      return true;

   //PalmOS.
   if (DetectPalmOS())
      return true;

   //Otherwise, return false.
   return false;
};


//**************************
// Detects if the current device is a mobile device.
//  This method catches most of the popular modern devices.
function DetectMobileQuick()
{
   //Attempt to detect most mobile devices, 
   //   especially mass market feature phones.
   // NOTE: Doesn't usually work reliably...
   if (uagent.search(deviceWap) > -1   || 
	uagent.search(deviceMidp) > -1 ||
	uagent.search(deviceWml) > -1  ||
	uagent.search(deviceBrew) > -1  )
   {
      return true;
   }

   //Detect for most smartphones.
   if (DetectSmartphone())
      return true;

   //Check for a NetFront browser
   if (uagent.search(engineNetfront) > -1)
      return true;

   //Check for a Playstation
   if (uagent.search(devicePlaystation) > -1)
      return true;

   //Check for a generic PDA
   if (uagent.search(devicePda) > -1)
      return true;

   return false;
};


//**************************
// Detects in a more comprehensive way if the current device is a mobile device.
function DetectMobileLonger()
{
   //Run the quick check first.
   if (DetectMobileQuick())
      return true;

   //Check for NTT Docomo
   if (uagent.search(svcDocomo) > -1)
      return true;

   //Check for KDDI
   if (uagent.search(svcKddi) > -1)
      return true;

   //Check for Nintendo DS
   if (uagent.search(deviceNintendoDs) > -1)
      return true;

   //Check for Vodafone 3G
   if (uagent.search(svcVodafone) > -1)
      return true;

   //Finally, detect for certain very old devices with stupid useragent strings.
   if (uagent.search(manuSamsung1) > -1 ||
	uagent.search(manuSonyEricsson) > -1 || 
	uagent.search(manuericsson) > -1)
   {
      return true;
   }

   return false;
};
/**********************************************************************************************************************/
/************************************** END MOBILE BROWSER DETECTION CODE *********************************************/
/**********************************************************************************************************************/
/*
var medioPortal = "";
if(typeof(url_portal) != "undefined"){
	medioPortal = url_portal.replace("www.", "").replace("www-origin.", "");
}else{
	medioPortal = location.href.split('/')[2].replace("www.","").replace("www-origin.", "");
}
*/
//añadido por jsj inSkin
var inSkin = false;

var iCont = 0;
var iWidth1 = 0;
var iHeight1 = 0;
var sDiv1 = "";
var sFile1 = "";
var sPreview1 = "";
var floating1 = false;
var fullscreen = false;
var sZonas = "";
var idWMPlayer = "";
function getKeyWords(title) {
	title = title.toLowerCase();
	title = title.replace(/[àáâä]+/g, "a");
	title = title.replace(/[éèêë]+/g, "e");
	title = title.replace(/[ìíîï]+/g, "i");
	title = title.replace(/[óòôö]+/g, "o");
	title = title.replace(/[úùûü]+/g, "u");
	title = title.replace(/[ç]+/g, "c");
	title = title.replace(/\b/g, "_");
	title = title.replace(/\W/g, "");
	var words = title.split("_");
	var keywords = "";
	for ( var i = 0; i < words.length; i++) {
		if (3 < words[i].length)
			keywords += "," + words[i];
	}
	if (keywords != "")
		keywords = keywords.substring(1);

	return keywords;
}
//Player antiguo
function showPlayer(sPlayer, sTags, sZonas, bStretch) {
	var fo = new SWFObject(sPlayer, "movie_player", iWidth1, iHeight1, 8,
			"#000000");
	fo.addParam("allowfullscreen", fullscreen1);
	fo.addParam("wmode", "transparent");
	fo.addVariable("image", sPreview1);
	fo.addVariable("width", iWidth1);
	if (typeof (bStretch) != 'undefined')
		fo.addVariable("overstretch", bStretch);
	else
		fo.addVariable("overstretch", "true");
	fo.addVariable("height", iHeight1);
	fo.addVariable("file", sFile1);
	if (floating1)
		fo.addVariable("displayheight", iHeight1);
	fo.addVariable("sZonas", sZonas);
	fo.addVariable("p1U", sZonas);
	fo.addVariable("sTags", sTags);
	fo.write(sDiv1);
}

function loadMethodeVideo(div, w, h, sFile, sPreview, fullscreen, floating,
		sPortal, sZonas, sTitle, sCategory, bStretch) {
	
	/*var opciones = {
		categoriaPubli: sCategory,
		titulo: sTitle,
		imgPrevia: sPreview,
		site: sPortal
	};
	
	PlayerWebTV.cargaVideo(div, sFile, w, h, opciones);*/
	loadMultimedia(div, w, h, sFile, sPreview, sPortal, sTitle, sCategory);
}

function prueba(){
	$("#playervid").attr("style","position: absolute; top: 26px; left: 22px; height: 160px; width: 268px;");
}

/*NEW PLAYER*/
function loadMultimedia(div, w, h, sFile, sPreview, sPortal, sTitle, sCategory, opciones) {	
	var opcionesOK = null;
	if(opciones == null || opciones == undefined){
		opciones = '';
	}
	//ESPECIFICO GRADA360
	if(sPortal == 'grada360')	
		opciones.idModulo = 'VOC_playerGrada360';
	//FIN ESPECIFICO GRADA360
	opcionesOK = {
			modoExtendido: "player",
			idModulo: (opciones.idModulo == undefined) ? 'VOC_playerVideo' : opciones.idModulo,
	
			medio: (opciones.site == undefined) ? sPortal : opciones.site,
			
			edicionLocal: (opciones.edicionLocal == undefined) ? '' : opciones.edicionLocal,
			
			idDivVideo: div,
			idVideo: sFile,
			origenVideo: (opciones.categoriaPubli == undefined) ? sCategory : opciones.categoriaPubli,
	 		nameVideo: (opciones.titulo == undefined) ? sTitle : opciones.categoriaPubli,
	 		linkURLVideo: (opciones.urlTitulo == undefined) ? '' : opciones.urlTitulo,
	 		longDescriptionVideo: (opciones.entradilla == undefined) ? '' : opciones.entradilla,
	 		shortDescriptionVideo: (opciones.entradilla == undefined) ? '' : opciones.entradilla,
	 		widthVideo: w,
	 		heightVideo: h,
	 		stillURLVideo: (opciones.imgPrevia == undefined) ? sPreview : opciones.imgPrevia,
	 		
	 		apoyoTexto: (opciones.apoyoTexto == undefined) ? '' : opciones.apoyoTexto,
			apoyoURL: (opciones.apoyoURL == undefined) ? '' : opciones.apoyoURL,
			antetituloTexto: (opciones.antetituloTexto == undefined) ? '' : opciones.antetituloTexto,
	
			capaModal: (opciones.capaModal == undefined) ? true : opciones.capaModal,
			publicidadOn: (opciones.publicidadOn == undefined) ? true : opciones.publicidadOn,
			comentarios: (opciones.comentarios == undefined) ? '' : opciones.comentarios,
			redesSociales: (opciones.redesSociales == undefined) ? true : opciones.redesSociales,
	
			imgPatrocinio: (opciones.imgPatrocinio == undefined) ? '' : opciones.imgPatrocinio,
			urlPatrocinio: (opciones.urlPatrocinio == undefined) ? '' : opciones.urlPatrocinio,
			clickcommand: (opciones.clickcommand == undefined) ? '' : opciones.clickcommand,
			
			classVideo: (opciones.classVideo == undefined) ? '' : opciones.classVideo,
			
			usoResizer: (opciones.usoResizer == undefined) ? true : opciones.usoResizer
		    };
	cargaVideo(opcionesOK);
}

function cargaVideo(opciones){
	if(opciones == null || opciones == undefined){
		opciones = '';
	}
	opciones = {
			modoExtendido: "player",
			idModulo: (opciones.idModulo == undefined) ? 'VOC_playerVideo' : opciones.idModulo,
			
			edicionLocal: (opciones.edicionLocal == undefined) ? '' : opciones.edicionLocal,
	
			medio: (opciones.medio == undefined) ? '' : opciones.medio,
			
			idDivVideo: (opciones.idDivVideo == undefined) ? '' : opciones.idDivVideo,
			idVideo: (opciones.idVideo == undefined) ? '' : opciones.idVideo,
			linkURLVideo: (opciones.linkURLVideo == undefined) ? '' : opciones.linkURLVideo,
			origenVideo: (opciones.origenVideo == '') ? 'bc' : opciones.origenVideo,
	 		nameVideo: (opciones.nameVideo == undefined) ? '' : opciones.nameVideo,
	 		linkURLVideo: (opciones.linkURLVideo == undefined) ? '' : opciones.linkURLVideo,
	 		longDescriptionVideo: (opciones.longDescriptionVideo == undefined) ? '' : opciones.longDescriptionVideo,
	 		shortDescriptionVideo: (opciones.shortDescriptionVideo == undefined) ? '' : opciones.shortDescriptionVideo,
	 		widthVideo: (opciones.widthVideo == undefined) ? '' : opciones.widthVideo,
	 		heightVideo: (opciones.heightVideo == undefined) ? '' : opciones.heightVideo,
	 		stillURLVideo: (opciones.stillURLVideo == undefined) ? '' : opciones.stillURLVideo,
	 		
	 		pieVideo: (opciones.pieVideo == undefined) ? '' : opciones.pieVideo,
	 		firmaVideo: (opciones.firmaVideo == undefined) ? '' : opciones.firmaVideo,
	 		fechaVideo: (opciones.fechaVideo == undefined) ? '' : opciones.fechaVideo,
	 		authorVideo: (opciones.authorVideo == undefined) ? '' : opciones.authorVideo,
	 				
	 		apoyoTexto: (opciones.apoyoTexto == undefined) ? '' : opciones.apoyoTexto,
			apoyoURL: (opciones.apoyoURL == undefined) ? '' : opciones.apoyoURL,
			antetituloTexto: (opciones.antetituloTexto == undefined) ? '' : opciones.antetituloTexto,
	
			capaModal: (opciones.capaModal == undefined) ? true : opciones.capaModal,
			publicidadOn: (opciones.publicidadOn == undefined) ? true : opciones.publicidadOn,
			comentarios: (opciones.comentarios == undefined) ? '' : opciones.comentarios,
			redesSociales: (opciones.redesSociales == undefined) ? true : opciones.redesSociales,
	
			imgPatrocinio: (opciones.imgPatrocinio == undefined) ? '' : opciones.imgPatrocinio,
			urlPatrocinio: (opciones.urlPatrocinio == undefined) ? '' : opciones.urlPatrocinio,
			clickcommand: (opciones.clickcommand == undefined) ? '' : opciones.clickcommand,
			
			usoResizer: (opciones.usoResizer == undefined) ? true : opciones.usoResizer,
			
			classVideo: (opciones.classVideo == undefined) ? '' : opciones.classVideo,
			
			autoStartVideo: (opciones.autoStartVideo == undefined) ? true : opciones.autoStartVideo
		    };

	if(opciones.origenVideo == 'methode')
		opciones.origenVideo = 'bc';
	if (typeof (OAS_sitepage) == "undefined")
		var  OAS_sitepage = '';
	opciones.inskin = getInskin(OAS_sitepage);
	opciones.charset = getCharset(); 
	opciones.location = location.host;

	var playerVideoDomain = playerVideoGetDomain(opciones.medio);
	playerVideoDomain = playerVideoDomain.replace("http://", "").replace("www.", "").replace("www-origin.", "");
	var url = 'http://modulos-mm.' + playerVideoDomain + '/includes/manuales/videos/php/proxyModgen.php';
	//var url = 'http://194.30.12.10/includes/manuales/videos/php/proxyModgen_v2.php';
	//var url = 'http://modgen-pre.vocento.com/includes/manuales/videos/php/proxyModgen_v2.php';
	//var url = 'http://' + opciones.location + '/includes/manuales/videos/php/proxyModgen_v2.php';
	var url = url + '?'; 
	
	urlTemp = ''; 
	for (key in opciones){
		var value = "" + opciones[key];
		if(value != "")
			urlTemp = urlTemp + key + '=' + escape(value) + '&';
	}
	url = url + urlTemp.substring(0, urlTemp.length -1);

	if(jQuery.browser.msie && parseInt(jQuery.browser.version, 10) < 8) {
		jQuery.support.cors = true;
		//utilizamos la libreria easyxdm
		var rpc = new easyXDM.Rpc({
							        remote: "http://modulos-mm." + playerVideoDomain + "/cors.html"
							    },
							    {
							        remote: {
							            	request: {}
							        		}
							    });
		rpc.request({
				        url: url.replace("http://modulos-mm." + playerVideoDomain, ""),
				        method : "GET"
				    }, function(response) {
								        var data = response.data;
								        var jQueryIdDivVideo = "#" + opciones.idDivVideo;
										var jQueryIdDivVideo = jQueryIdDivVideo.replace(/[.]/gi,'\\\.');
								        jQuery(jQueryIdDivVideo).html(data);
				    });
	}else if (jQuery.browser.msie && parseInt(jQuery.browser.version, 10) >= 8 && window.XDomainRequest) {
        // Use Microsoft XDR
        var xdr = new XDomainRequest();
        xdr.open("get", url);
        xdr.onload = function() {
				                // XDomainRequest doesn't provide responseXml, so if you need it:
				                var dom = new ActiveXObject("Microsoft.XMLDOM");
				                dom.async = false;
				                //alert("XDR Response *" + xdr.responseText + "*");
				                //dom.loadXML(xdr.responseText);
				                var data = xdr.responseText;
				                var jQueryIdDivVideo = "#" + opciones.idDivVideo;
								var jQueryIdDivVideo = jQueryIdDivVideo.replace(/[.]/gi,'\\\.');
				                jQuery(jQueryIdDivVideo).html(data);
        };
        xdr.send();
    }else{
    	if((typeof jQuery_1_8_1 == "undefined") ||  (jQuery_1_8_1 == null)){
			//jQuery.getScript('http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js', function() {
			jQuery.getScript('http://nets.abc.es/jquery/1.8.1/jquery.min.js', function() {
		    	jQuery_1_8_1 = jQuery.noConflict(true);
		    	jQuery_1_8_1.support.cors = true;
		    	jQuery_1_8_1.ajax({
								url: url,
								//crossDomain: true,
								dataType: "html",
								success: function(data) {
														var jQueryIdDivVideo = "#" + opciones.idDivVideo;
														var jQueryIdDivVideo = jQueryIdDivVideo.replace(/[.]/gi,'\\\.');
														jQuery(jQueryIdDivVideo).html(data);
														},
								error: function(XMLHttpRequest, textStatus, errorThrown){
																						//alert("Error");
																						}
								});
		    });
		}else{
			jQuery_1_8_1.support.cors = true;
			jQuery_1_8_1.ajax({
								url: url,
								//crossDomain: true,
								dataType: "html",
								success: function(data) {
														var jQueryIdDivVideo = "#" + opciones.idDivVideo;
														var jQueryIdDivVideo = jQueryIdDivVideo.replace(/[.]/gi,'\\\.');
														jQuery(jQueryIdDivVideo).html(data);
														},
								error: function(XMLHttpRequest, textStatus, errorThrown){
																						//alert("Error");
																						}
								});
		}
	}

}

function openVideoCapaModal(opciones) {
	if(opciones.origenVideo == 'bc'){
		//comprobamos si cargar el brightcoveExperience
		if(!window.brightcove){
			jQuery.getScript('http://admin.brightcove.com/js/BrightcoveExperiences.js', function() {
				openVideoCapaModal2(opciones);
				htmlSupport = brightcove.checkHtmlSupport();
			});
		}else{
			openVideoCapaModal2(opciones);
		}
	}else if(opciones.origenVideo == 'perform'){
		//comprobamos si cargar el swfobject
		//comprobamos si cargar el performgroup
		if(!window.addCustomPlayer){
			jQuery.getScript('http://static.eplayer.performgroup.com/flash/js/swfobject.js', function() {
				jQuery.getScript('http://static.eplayer.performgroup.com/flash/js/performgroup.js', function() {
					openVideoCapaModal2(opciones);
				});
			});
		}else{
			openVideoCapaModal2(opciones);
		}
	}else{
		openVideoCapaModal2(opciones);
	}
}


function openVideoCapaModal2(opciones){
	//plantilla ShowVideo
	opciones.idModulo = opciones.idModulo.replace('ShowVideo', '');
	opciones.idModulo = opciones.idModulo + 'ShowVideo';

	var playerVideoDomain = playerVideoGetDomain(opciones.medio);
	playerVideoDomain = playerVideoDomain.replace("http://", "").replace("www.", "").replace("www-origin.", "");
	var url = 'http://modulos-mm.' + playerVideoDomain + '/includes/manuales/videos/php/proxyModgen.php';
	//var url = 'http://194.30.12.10/includes/manuales/videos/php/proxyModgen_v2.php';
	//var url = 'http://modgen-pre.vocento.com/includes/manuales/videos/php/proxyModgen_v2.php';
	//var url = 'http://' + opciones.location + '/includes/manuales/videos/php/proxyModgen_v2.php';
	var url = url + '?'; 
	
	urlTemp = ''; 
	for (key in opciones){
		var value = "" + opciones[key];
		if(value != "")
			urlTemp = urlTemp + key + '=' + escape(value) + '&';
	}
	url = url + urlTemp.substring(0, urlTemp.length -1);

	if (jQuery.browser.msie && parseInt(jQuery.browser.version, 10) < 8) {
		jQuery.support.cors = true;
		//utilizamos la libreria easyxdm
		var rpc = new easyXDM.Rpc({
							        remote: "http://modulos-mm." + playerVideoDomain + "/cors.html"
							    },
							    {
							        remote: {
							            	request: {}
							        		}
							    });
		rpc.request({
				        url: url.replace("http://modulos-mm." + playerVideoDomain, ""),
				        method : "GET"
				    }, function(response) {
								        var data = response.data;
								        var idDivModal = opciones.idDivVideo.replace(/\./g, '-') + "-_-modal";
										//caso normal
										if(opciones.idDivVideo.indexOf("ver_video") == -1){
											var jQueryIdDivVideo = "#" + opciones.idDivVideo;
											var jQueryIdDivVideo = jQueryIdDivVideo.replace(/[.]/gi,'\\\.');
											jQuery(jQueryIdDivVideo).html(data);
										//caso loadmultimediasinfoto (idDivVideo = "ver_video...")
										}else{
											idDivModal = opciones.idDivVideo + "-_-modal";
											var jQueryIdDivVideo = "#" + idDivModal;
											jQuery(jQueryIdDivVideo).html(data);
										}
						
										if (jQuery("#photo-" + idDivModal + "-modal").length){
											var simpleModalJS = "";
											var playerVideoDomain = playerVideoGetDomain(opciones.dominio);
											playerVideoDomain = playerVideoDomain.replace("http://", "").replace("www.", "").replace("www-origin.", "");
											var playerVideoDomain = opciones.dominio.replace("http://", "").replace("www.", "").replace("www-origin.", "").replace("pre-www.", "");
											
											var arrayEntornos = new Array();
											arrayEntornos[0] = 'www.' + playerVideoDomain; 
											arrayEntornos[1] = 'www-origin.' + playerVideoDomain; 
											arrayEntornos[2] = 'desarrollo.' + playerVideoDomain; 
											arrayEntornos[3] = 'rediseno.' + playerVideoDomain;
											arrayEntornos[4] = 'integracion-rediseno.'  + playerVideoDomain;
											arrayEntornos[5] = 'redisenodev.' + playerVideoDomain; 
											arrayEntornos[6] = 'desarrollo2010.' + playerVideoDomain; 
											arrayEntornos[7] = 'integracion2010.'  + playerVideoDomain;
											arrayEntornos[8] = 'pre-www.'  + playerVideoDomain;
											arrayEntornos[9] = 'pre.colpisa.vocento.com';
											var entorno = location.host.replace("http://", "");
											if(jQuery.inArray(entorno, arrayEntornos) != -1){
												simpleModalJS = "/js/jquery.simplemodal.js";
											}else{
												simpleModalJS = opciones.dominio + "/js/jquery.simplemodal.js";
											}
									
											jQuery("object").attr("z-index", "-1");
											jQuery("embed").attr("wmode", "transparent");
									
											jQuery("param[name|=wmode]").attr("value", "transparent");
											jQuery("#photo-" + idDivModal + "-modal embed").attr("wmode", "opaque");
									
											jQuery("#photo-" + idDivModal + "-modal").attr("z-index", "10000");
									
											jQuery.getScript(simpleModalJS, function() {
												jQuery("#photo-" + idDivModal + "-modal").modal();
												jQuery("#photo-" + idDivModal + "-modal").show();
											});
											
											jQuery("#photo-" + idDivModal + "-modal").removeClass();
											jQuery("#photo-" + idDivModal + "-modal").addClass("player-modal");
										}else{
											//alert("#photo-" + idDivModal + "-modal NO EXISTE");
										}
				    });
	}else if (jQuery.browser.msie && parseInt(jQuery.browser.version, 10) >= 8 && window.XDomainRequest) {
        // Use Microsoft XDR
        var xdr = new XDomainRequest();
        xdr.open("get", url);
        xdr.onload = function() {
				                // XDomainRequest doesn't provide responseXml, so if you need it:
				                var dom = new ActiveXObject("Microsoft.XMLDOM");
				                dom.async = false;
				                //alert("XDR Response *" + xdr.responseText + "*");
				                //dom.loadXML(xdr.responseText);
				                var data = xdr.responseText;
								var idDivModal = opciones.idDivVideo.replace(/\./g, '-') + "-_-modal";
								//caso normal
								if(opciones.idDivVideo.indexOf("ver_video") == -1){
									var jQueryIdDivVideo = "#" + opciones.idDivVideo;
									var jQueryIdDivVideo = jQueryIdDivVideo.replace(/[.]/gi,'\\\.');
									jQuery(jQueryIdDivVideo).html(data);
								//caso loadmultimediasinfoto (idDivVideo = "ver_video...")
								}else{
									idDivModal = opciones.idDivVideo + "-_-modal";
									var jQueryIdDivVideo = "#" + idDivModal;
									jQuery(jQueryIdDivVideo).html(data);
								}
				
								if (jQuery("#photo-" + idDivModal + "-modal").length){
									var simpleModalJS = "";
									var playerVideoDomain = playerVideoGetDomain(opciones.dominio);
									playerVideoDomain = playerVideoDomain.replace("http://", "").replace("www.", "").replace("www-origin.", "");
									var playerVideoDomain = opciones.dominio.replace("http://", "").replace("www.", "").replace("www-origin.", "").replace("pre-www.", "");
									
									var arrayEntornos = new Array();
									arrayEntornos[0] = 'www.' + playerVideoDomain; 
									arrayEntornos[1] = 'www-origin.' + playerVideoDomain; 
									arrayEntornos[2] = 'desarrollo.' + playerVideoDomain; 
									arrayEntornos[3] = 'rediseno.' + playerVideoDomain;
									arrayEntornos[4] = 'integracion-rediseno.'  + playerVideoDomain;
									arrayEntornos[5] = 'redisenodev.' + playerVideoDomain; 
									arrayEntornos[6] = 'desarrollo2010.' + playerVideoDomain; 
									arrayEntornos[7] = 'integracion2010.'  + playerVideoDomain;
									arrayEntornos[8] = 'pre-www.'  + playerVideoDomain;
									arrayEntornos[9] = 'pre.colpisa.vocento.com';
									var entorno = location.host.replace("http://", "");
									if(jQuery.inArray(entorno, arrayEntornos) != -1){
										simpleModalJS = "/js/jquery.simplemodal.js";
									}else{
										simpleModalJS = opciones.dominio + "/js/jquery.simplemodal.js";
									}
							
									jQuery("object").attr("z-index", "-1");
									jQuery("embed").attr("wmode", "transparent");
							
									jQuery("param[name|=wmode]").attr("value", "transparent");
									jQuery("#photo-" + idDivModal + "-modal embed").attr("wmode", "opaque");
							
									jQuery("#photo-" + idDivModal + "-modal").attr("z-index", "10000");
							
									jQuery.getScript(simpleModalJS, function() {
										jQuery("#photo-" + idDivModal + "-modal").modal();
										jQuery("#photo-" + idDivModal + "-modal").show();
									});
									
									jQuery("#photo-" + idDivModal + "-modal").removeClass();
									jQuery("#photo-" + idDivModal + "-modal").addClass("player-modal");
								}else{
									//alert("#photo-" + idDivModal + "-modal NO EXISTE");
								}
        };
        xdr.send();
    }else{
    	jQuery_1_8_1.support.cors = true;
		jQuery_1_8_1.ajax({
						url: url,
						//crossDomain: true,
						dataType: "html",
						success: function(data) {
													var idDivModal = opciones.idDivVideo.replace(/\./g, '-') + "-_-modal";
													//caso normal
													if(opciones.idDivVideo.indexOf("ver_video") == -1){
														var jQueryIdDivVideo = "#" + opciones.idDivVideo;
														var jQueryIdDivVideo = jQueryIdDivVideo.replace(/[.]/gi,'\\\.');
														jQuery(jQueryIdDivVideo).html(data);
													//caso loadmultimediasinfoto (idDivVideo = "ver_video...")
													}else{
														idDivModal = opciones.idDivVideo + "-_-modal";
														var jQueryIdDivVideo = "#" + idDivModal;
														jQuery(jQueryIdDivVideo).html(data);
													}
				
													if (jQuery("#photo-" + idDivModal + "-modal").length){
														var simpleModalJS = "";
														var playerVideoDomain = playerVideoGetDomain(opciones.dominio);
														playerVideoDomain = playerVideoDomain.replace("http://", "").replace("www.", "").replace("www-origin.", "");
														var playerVideoDomain = opciones.dominio.replace("http://", "").replace("www.", "").replace("www-origin.", "").replace("pre-www.", "");
														
														var arrayEntornos = new Array();
														arrayEntornos[0] = 'www.' + playerVideoDomain; 
														arrayEntornos[1] = 'www-origin.' + playerVideoDomain; 
														arrayEntornos[2] = 'desarrollo.' + playerVideoDomain; 
														arrayEntornos[3] = 'rediseno.' + playerVideoDomain;
														arrayEntornos[4] = 'integracion-rediseno.'  + playerVideoDomain;
														arrayEntornos[5] = 'redisenodev.' + playerVideoDomain; 
														arrayEntornos[6] = 'desarrollo2010.' + playerVideoDomain; 
														arrayEntornos[7] = 'integracion2010.'  + playerVideoDomain;
														arrayEntornos[8] = 'pre-www.'  + playerVideoDomain;
														arrayEntornos[9] = 'pre.colpisa.vocento.com';
														var entorno = location.host.replace("http://", "");
														if(jQuery.inArray(entorno, arrayEntornos) != -1){
															simpleModalJS = "/js/jquery.simplemodal.js";
														}else{
															simpleModalJS = opciones.dominio + "/js/jquery.simplemodal.js";
														}
												
														jQuery("object").attr("z-index", "-1");
														jQuery("embed").attr("wmode", "transparent");
												
														jQuery("param[name|=wmode]").attr("value", "transparent");
														jQuery("#photo-" + idDivModal + "-modal embed").attr("wmode", "opaque");
												
														jQuery("#photo-" + idDivModal + "-modal").attr("z-index", "10000");
												
														jQuery.getScript(simpleModalJS, function() {
															jQuery("#photo-" + idDivModal + "-modal").modal();
															jQuery("#photo-" + idDivModal + "-modal").show();
														});
														
														jQuery("#photo-" + idDivModal + "-modal").removeClass();
														jQuery("#photo-" + idDivModal + "-modal").addClass("player-modal");
													}else{
														//alert("#photo-" + idDivModal + "-modal NO EXISTE");
													}
												},
						error: function(XMLHttpRequest, textStatus, errorThrown){
																				//alert("Error");
																				}
						});
	}
}

function openVideo(opciones) {
	if(opciones.origenVideo == 'bc'){
		//comprobamos si cargar el brightcoveExperience
		if (typeof(brightcove) == "undefined"){
			jQuery.getScript('http://admin.brightcove.com/js/BrightcoveExperiences.js', function() {
				openVideo2(opciones);
				htmlSupport = brightcove.checkHtmlSupport();
			});
		}else{
			openVideo2(opciones);
		}
	}else if(opciones.origenVideo == 'perform'){
		//comprobamos si cargar el swfobject
		//comprobamos si cargar el performgroup
		if (typeof(addCustomPlayer) == "undefined"){
			jQuery.getScript('http://static.eplayer.performgroup.com/flash/js/swfobject.js', function() {
				jQuery.getScript('http://static.eplayer.performgroup.com/flash/js/performgroup.js', function() {
					openVideo2(opciones);
				});
			});
		}else{
			openVideo2(opciones);
		}
	}else{
		openVideo2(opciones);
	}
}

function openVideo2(opciones) {
	//plantilla ShowVideo
	opciones.idModulo = opciones.idModulo.replace('ShowVideo', '');
	opciones.idModulo = opciones.idModulo + 'ShowVideo';

	var playerVideoDomain = playerVideoGetDomain(opciones.medio);
	playerVideoDomain = playerVideoDomain.replace("http://", "").replace("www.", "").replace("www-origin.", "");
	var url = 'http://modulos-mm.' + playerVideoDomain + '/includes/manuales/videos/php/proxyModgen.php';
	//var url = 'http://194.30.12.10/includes/manuales/videos/php/proxyModgen_v2.php';
	//var url = 'http://modgen-pre.vocento.com/includes/manuales/videos/php/proxyModgen_v2.php';
	//var url = 'http://' + opciones.location + '/includes/manuales/videos/php/proxyModgen_v2.php';
	var url = url + '?'; 
	
	urlTemp = ''; 
	
	for (key in opciones){
		var value = "" + opciones[key];
		if(value != "")
			urlTemp = urlTemp + key + '=' + escape(value) + '&';
	}
	url = url + urlTemp.substring(0, urlTemp.length -1);


	if (jQuery.browser.msie && parseInt(jQuery.browser.version, 10) < 8) {
		jQuery.support.cors = true;
		var rpc = new easyXDM.Rpc({
							        remote: "http://modulos-mm." + playerVideoDomain + "/cors.html"
							    },
							    {
							        remote: {
							            	request: {}
							        		}
							    });
		rpc.request({
				        url: url.replace("http://modulos-mm." + playerVideoDomain, ""),
				        method : "GET"
				    }, function(response) {
								        var data = response.data;
								        var jQueryIdDivVideo = "#" + opciones.idDivVideo;
										var jQueryIdDivVideo = jQueryIdDivVideo.replace(/[.]/gi,'\\\.');
				                		jQuery(jQueryIdDivVideo).html(data);
				    });
	}else if (jQuery.browser.msie && parseInt(jQuery.browser.version, 10) >= 8 && window.XDomainRequest) {
        // Use Microsoft XDR
        var xdr = new XDomainRequest();
        xdr.open("get", url);
        xdr.onload = function() {
				                // XDomainRequest doesn't provide responseXml, so if you need it:
				                var dom = new ActiveXObject("Microsoft.XMLDOM");
				                dom.async = false;
				                //alert("XDR Response *" + xdr.responseText + "*");
				                //dom.loadXML(xdr.responseText);
				                var data = xdr.responseText;
				                var jQueryIdDivVideo = "#" + opciones.idDivVideo;
								var jQueryIdDivVideo = jQueryIdDivVideo.replace(/[.]/gi,'\\\.');
				                jQuery(jQueryIdDivVideo).html(data);
        };
        xdr.send();
    }else{
    	jQuery_1_8_1.support.cors = true;
		jQuery_1_8_1.ajax({
						url: url,
						//crossDomain: true,
						dataType: "html",
						success: function(data) {
												var jQueryIdDivVideo = "#" + opciones.idDivVideo;
												var jQueryIdDivVideo = jQueryIdDivVideo.replace(/[.]/gi,'\\\.');
												jQuery(jQueryIdDivVideo).html(data);
												},
						error: function(XMLHttpRequest, textStatus, errorThrown){
																				//alert("Error");
																				}
						});
	}
}

function getInskin(OAS_sitepage) {

	var inskin = 'false';
	var respuesta = '';
	
	//if(DetectMobileLonger()){
	//	inSkin = 'false';
	//}
	inskin = (htmlSupport) ? 'false' : 'true';
	
	if(typeof OAS_sitepage=="undefined"){
		OAS_sitepage = '';

	}		
	var OAS = new Array(	'vocento.abc', 
				'vocento.abcdesevilla', 
				'vocento.diariosur', 
				'vocento.elcomerciodigital', 
				'vocento.elcorreodigital', 
				'vocento.eldiariomontanes', 
				'vocento.diariovasco', 
				'vocento.hoy', 
				'vocento.ideal', 
				'vocento.larioja', 
				'vocento.lasprovincias', 
				'vocento.laverdad', 
				'vocento.lavozdigital', 
				'vocento.nortecastilla'
			    );
	
	if (OAS_sitepage!=''){

		var campos = OAS_sitepage.split('/');		
		var campos2 = campos[0].split('.');
		
		switch (campos2[1]) {
			case 'elcomercio-sa':
				var periodico = 'elcomerciodigital';
				break;
			case 'elcomercio':
				var periodico = 'elcomerciodigital';
				break;
			case 'elnortedecastilla':
				var periodico = 'nortecastilla';
				break;
			case 'diario-elcorreo':
				var periodico = 'elcorreodigital';
				break;
			case 'la-verdad':
				var periodico = 'laverdad';
				break;
			case 'lavozdecadiz':
				var periodico = 'lavozdigital';
				break;
			default:
				var periodico = campos2[1];
				break;	
		}
		
		//var ediciones = new Array('alava', 'vizcaya', 'aviles', 'gijon', 'oviedo', 'almeria', 'granada', 'jaen', 'alicante', 'valencia', 'albacete', 'murcia', 'cadiz', 'jerez', 'castellon');		
		var separador = '/';	
		var respuesta = 'vocento.' + periodico;
		var cont = 1;
		while( campos[cont] != null )
		{
			respuesta += separador + campos[cont];
			cont++;	
		}
		
		for(var i=0; i<OAS.length; i++){
			if(respuesta.indexOf(OAS[i])!=-1){
				inskin = 'true';
				break;
			}
		}
	}
	return inskin;
}

function playerVideoSubstringWithoutBreakingWords(text, length, tail) {
	text = text.replace(/^\s+/g,'').replace(/\s+$/g,'');
	txtl = text.length;
	if(txtl > length) {
		for( var i=1; text.charAt(length-i)!=" "; i++ ) {
			if(i == length) {
				return text.substring(0, length) + tail;
			}
		}
		for(;text.charAt(length-i)=="," || text.charAt(length-i)=="." || text.charAt(length-i)==" "; i++) {
			;
		}
		text = text.substring(0,length-i+1) + tail;
	}
	return text;
}

function playerVideoGetDomain(medio) {
	var dominio = 'http://www.elcorreo.com';
	if(medio == 'norcas' || medio == 'nortecastilla' || medio == 'elnortedecastilla'){
		dominio = 'http://www.elnortedecastilla.es';	
	}else if(medio == 'correo' || medio == 'elcorreo'){
		dominio = 'http://www.elcorreo.com';
	}else if(medio == 'elcomerciodigital' || medio == 'elcomercio'){
		dominio = 'http://www.elcomercio.es';
	}else if(medio == 'eldiariomontanes'){
		dominio = 'http://www.eldiariomontanes.es';
	}else if(medio == 'hoy'){
		dominio = 'http://www.hoy.es';				
	}else if(medio == 'lasprovincias'){
		dominio = 'http://www.lasprovincias.es';
	}else if(medio == 'ideal'){
		dominio = 'http://www.ideal.es';
	}else if(medio == 'sur' || medio == 'diariosur'){
		dominio = 'http://www.diariosur.es';
	}else if(medio == 'lavozdigital'){
		dominio = 'http://www.lavozdigital.es';
	}else if(medio == 'diariovasco'){
		dominio = 'http://www.diariovasco.com';
	}else if(medio == 'laverdad'){
		dominio = 'http://www.laverdad.es';
	}else if(medio == 'larioja'){
		dominio = 'http://www.larioja.com';
	}else if(medio == 'abc'){
		dominio = 'http://www.abc.es';
	}else if(medio == 'abcsevilla' || medio == 'abcdesevilla'){
		dominio = 'http://www.abcdesevilla.es';
	}else if(medio == 'que'){
		dominio = 'http://www.que.es';
	}else if(medio == 'vcfplay'){
		dominio = 'http://www.vcfplay.com';
	}else if(medio == 'finanzas'){
		dominio = 'http://www.finanzas.com';
	}else if(medio == 'hoymujer'){
		dominio = 'http://www.hoymujer.com';
	}else if(medio == 'grada360'){
		dominio = 'http://www.grada360.com';
	}else if(medio == 'colpisa'){
		dominio = 'http://www.colpisa.com';
	}else{
	}
	return dominio;
}

function getCharset() {
	charset = '';	
	if (typeof document.characterSet == 'undefined'){
		if (typeof document.charset == 'undefined'){
		}else{
			charset = document.charset;
		}
	}else{
		charset = document.characterSet;
	}
	return charset.toUpperCase();
}

function getNumComentarios(medio, idVideo){
	medio = (medio == 'abcdesevilla' || medio == 'abcsevilla') ? 'abc' : medio;
	var playerVideoDomain = playerVideoGetDomain(medio);
	playerVideoDomain = playerVideoDomain.replace("http://", "").replace("www.", "").replace("www-origin.", "");
	var urlComentarios = 'http://comm.' + playerVideoDomain + '/comentarios/xml/count.php?ids=' + medio + '-' + idVideo + '&json=1&callback=?'
	jQuery.getJSON(urlComentarios,function(data){
							try{
								//var numComentarios = data.resultados['abc-' + idVideo + ''];
								var numComentarios = data.resultados[medio + '-' + idVideo + ''];
								jQuery('#linkURLVideoopina_' + playerVideo_idDivModal).text(numComentarios + ' comentarios');
							}catch(err){
								jQuery('#linkURLVideoopina_' + playerVideo_idDivModal).text(' comentarios');
							}
						});
}
/*
//INICIO Control de video en capa modal
var player;
var modVP;
var modExp;
var modCon;
var modCvs;

var realizadoMediaChange;
var timestampMediaChange;
var finalizadoVideo;

var INSKIN_mediaPlay;
var INSKIN_triggerResize;
var INSKIN_esInSkinOn;			
var INSKIN_esFullScreen;	
var INSKIN_anchoPlayer;
var INSKIN_altoPlayer;

function myTemplateLoaded(experienceID) {
	//console.log("En myTemplateLoaded");
	player = brightcove.getExperience(experienceID);
	modVP = player.getModule(brightcove.api.modules.APIModules.VIDEO_PLAYER);
	modExp = player.getModule(brightcove.api.modules.APIModules.EXPERIENCE);
	modCon = player.getModule(brightcove.api.modules.APIModules.CONTENT); 
	modCvs = modExp.getElementByID("canvasinskin");     
	modExp.addEventListener(brightcove.api.events.ExperienceEvent.TEMPLATE_READY, templateReady);
	modExp.addEventListener(BCExperienceEvent.ENTER_FULLSCREEN, enterFullScreen); 
	modExp.addEventListener(BCExperienceEvent.EXIT_FULLSCREEN, exitFullScreen); 

	inicializa();
}

function inicializa(){
	//console.log("En inicializa");
	realizadoMediaChange = false;
	timestampMediaChange = new Date().getTime();
	finalizadoVideo = false;
	
	INSKIN_mediaPlay = false;
	INSKIN_triggerResize = false;
	INSKIN_esInSkinOn = false;			
	INSKIN_esFullScreen = false;	
	INSKIN_anchoPlayer = 640;
	INSKIN_altoPlayer = 360;
}

templateReady = function(event) {
	//console.log("En templateReady");
	modVP.addEventListener(brightcove.api.events.MediaEvent.CHANGE, mediaChange);
	modVP.addEventListener(brightcove.api.events.MediaEvent.PLAY, mediaPlay);
	modVP.addEventListener(brightcove.api.events.MediaEvent.COMPLETE, mediaComplete);
};

enterFullScreen = function(event) {
	//console.log('Pantalla completa ON');
	INSKIN_esFullScreen = true;
};								

exitFullScreen = function(event) {
	//console.log('Pantalla completa OFF');
	INSKIN_esFullScreen = false;
};								

mediaChange = function (event) {		
	//console.log("En mediaChange");
	realizadoMediaChange = true;
	timestampMediaChange = new Date().getTime();
	finalizadoVideo = false;

//alert("X:" + modVP.getX());
//alert("Y:" + modVP.getY());
	var id = 'video_' + playerVideo_idVideo;
	INSKIN_desactiva(id);
	setTimeout (function() { INSKIN_desactiva(id) }, 50);	

	jQuery('#antetituloTexto_' + playerVideo_idDivModal).text('');
	jQuery('#apoyoTexto_' + playerVideo_idDivModal).remove();
	jQuery('#apoyoURL_' + playerVideo_idDivModal).remove();
	jQuery('#authorVideo_' + playerVideo_idDivModal).text('Autor: ' + event.media.customFields.author);
	jQuery('#linkURLVideo_' + playerVideo_idDivModal).text(event.media.displayName);
	jQuery('#linkURLVideo_' + playerVideo_idDivModal).attr('href', event.media.linkURL);
	
	if (event.media.longDescription == null) {
		var newLongDescriptionVideo = '';
	} else {
		var newLongDescriptionVideo = playerVideoSubstringWithoutBreakingWords(event.media.longDescription, 200, '...');
	}

	jQuery('#longDescriptionVideo_' + playerVideo_idDivModal).text(newLongDescriptionVideo);
	jQuery('#linkURLVideoopina_' + playerVideo_idDivModal).attr('href', event.media.linkURL + '#opina');									
	jQuery('#facebookIframe_' + playerVideo_idDivModal).attr('src', 'http://www.facebook.com/plugins/like.php?href=' + event.media.linkURL + '&amp;layout=button_count&amp;show_faces=true&amp;width=120&amp;action=recommend&amp;font=arial&amp;colorscheme=light&amp;height=21');
	
	$('.twitter-share-button').remove();
	$('#twitterDiv_' + playerVideo_idDivModal).html('<a class="twitter-share-button" href="http://twitter.com/share" data-url="' + event.media.linkURL + '" data-text="' + event.media.longDescription + '" data-count="horizontal">Tweet</a>');
	$.getScript('http://platform.twitter.com/widgets.js');
			
	jQuery('#tuentiIframe_' + playerVideo_idDivModal).attr('href', 'http://www.tuenti.com/share?url=' + event.media.linkURL);									
}; 	

mediaPlay = function (event) {
	//console.log("En mediaPlay");
	INSKIN_mediaPlay = true;
	//alert("En mediaPlay");
	//alert(INSKIN_triggerResize);
	if(INSKIN_triggerResize){
		//alert("En dentro");
		//INSKIN_triggerResize = false;
		//INSKIN_mediaPlay = false;
		inicializa();
		var id = 'video_' + playerVideo_idVideo;
		//INSKIN_inicializa(id);
		var esConsecutivoAMediaChange = (realizadoMediaChange && (new Date().getTime() - timestampMediaChange < 500));
		
		// triggerResize es invocado cuando finaliza el video y hemos seleccionado repetirlo,  o cuando seleccionamos repetir otro -> Evitamos estos casos para activar InSkin, de manera que solo lo activamos cuando no se cumplen estos 2 casos
		if (!INSKIN_esInSkinOn && !esConsecutivoAMediaChange && !finalizadoVideo) {
			INSKIN_activa(id);
			setTimeout (function() { INSKIN_activa(id) }, 50);
		}
		else {
			INSKIN_desactiva(id);
			setTimeout (function() { INSKIN_desactiva(id) }, 50);	
		}
		
	}else{
		modVP.move(130,60);
		
		if (!INSKIN_esInSkinOn && !esConsecutivoAMediaChange && !finalizadoVideo) {
			modVP.move(0, 0);
			setTimeout (function() { modVP.move(0, 0) }, 50);
		}
		else {
			modVP.move(130, 60);
			setTimeout (function() { modVP.move(130, 60) }, 50);	
		}
		
	}
	realizadoMediaChange = false;
	finalizadoVideo = false;
};

mediaComplete = function(event) {
	//console.log("En videoCompleto");
	//alert("mediaComplete");
	var id = 'video_' + playerVideo_idVideo;
	INSKIN_desactiva(id);
	setTimeout (function() { INSKIN_desactiva(id) }, 50);
	finalizadoVideo = true;
}; 	

function triggerResize(size) {
	//console.log("En triggerResize");
	//console.log('size');
	//for (var i in size) { 
      	//	console.log(i + " = " + size[i]);
   	//} 
   	//console.log('size');
   	//alert("triggerResize");
	INSKIN_triggerResize = true;
	if(INSKIN_mediaPlay){
		//INSKIN_triggerResize = false;
		//INSKIN_mediaPlay = false;
		inicializa();
		var id = 'video_' + playerVideo_idVideo;
		//INSKIN_inicializa(id);
		var esConsecutivoAMediaChange = (realizadoMediaChange && (new Date().getTime() - timestampMediaChange < 500));
		
		// triggerResize es invocado cuando finaliza el video y hemos seleccionado repetirlo,  o cuando seleccionamos repetir otro -> Evitamos estos casos para activar InSkin, de manera que solo lo activamos cuando no se cumplen estos 2 casos
		if (!INSKIN_esInSkinOn && !esConsecutivoAMediaChange && !finalizadoVideo) {
			INSKIN_activa(id);
			setTimeout (function() { INSKIN_activa(id) }, 50);
		}
		else {
			INSKIN_desactiva(id);
			setTimeout (function() { INSKIN_desactiva(id) }, 50);	
		}
		

	}else{
		
		//if (!INSKIN_esInSkinOn && !esConsecutivoAMediaChange && !finalizadoVideo) {
		//	INSKIN_desactiva(id);
		//	setTimeout (function() { INSKIN_desactiva(id) }, 50);
		//}
		//else {
		//	INSKIN_activa(id);
		//	setTimeout (function() { INSKIN_activa(id) }, 50);	
		//}
		
	}
	realizadoMediaChange = false;
	finalizadoVideo = false;
}

//Inicio de codigo de manejo de funciones para inskin
function INSKIN_activa (id) {
	//console.log("En INSKIN_activa");
	INSKIN_esInSkinOn = true;
	INSKIN_changeSize (id, 900, 460);
	
	// Nos quedamos  con el ID del video a partir del ID de la capa
	var idVideo = id;
	if (id.indexOf('video_') != -1) idVideo = id.substring ('video_'.length);
	
	// Adaptamos estilos de la capa
	jQuery('#capaVideo_' + idVideo).attr('style', 'width: 900px; height: 460px');
	jQuery('#simplemodal-container2').removeClass();
	jQuery('#simplemodal-container2').addClass('simplemodal-inskin');
	var ancho = window.innerWidth || document.documentElement.clientWidth;
	var newLeft = (ancho - 900) / 2;
	jQuery('#simplemodal-container2').css('left', newLeft);
}

function INSKIN_desactiva (id) {
	//console.log("En INSKIN_desactiva");
	
	INSKIN_esInSkinOn = false;
	INSKIN_changeSize(id, 640, 360);
	
	// Nos quedamos  con el ID del video a partir del ID de la capa
	var idVideo = id;
	if (id.indexOf('video_') != -1) idVideo = id.substring ('video_'.length);
	
	// Adaptamos estilos de la capa
	jQuery('#capaVideo_' + idVideo).attr('style', 'width:640px; height:360px;');
	jQuery('#simplemodal-container2').removeClass();
	jQuery('#simplemodal-container2').addClass('simplemodal-container2');
	var ancho = window.innerWidth || document.documentElement.clientWidth;
	var newLeft = (ancho - 640) / 2;
	jQuery('#simplemodal-container2').css('left', newLeft);
	
	inicializa();
}

function INSKIN_changeSize (id, width, height) {
	//if ((INSKIN_canvasppal == null) || (INSKIN_experienceModule == null) || (INSKIN_videoPlayer == null)) INSKIN_inicializa (id);

	var object_video = document.getElementById (id);
	object_video.width = width;
	object_video.height = height;
	modCvs.setSize(width,height);
	modExp.setSize(width,height);
	//alert("width"+width);
	if (width == 640) {
		modVP.setSize(640,360);
		modVP.move(0,0);
	}else {
		modVP.setSize(640,360);
		modVP.move(130,60);
	}
}

//Fin de codigo de manejo de funciones para inskin	
//FIN Control de video en capa modal
*/
var onTemplateLoaded; 
var onTemplateReady;
var bcExp;
var modVP;
var modExp;
var modCon;

var nextVideo = 0;
//var videos = new Array(269766147900199, 2697633446001);
var videos = new Array();

errorTime = 0;
retryTime = 5000;

Date.now = Date.now || function() { return +new Date; };

onTemplateLoaded = function (experienceID) {
//alert("INICIO_LOAD");
//console.log("INICIO_LOAD");
    bcExp = brightcove.api.getExperience(experienceID);
    modVP = bcExp.getModule(brightcove.api.modules.APIModules.VIDEO_PLAYER);
    modExp = bcExp.getModule(brightcove.api.modules.APIModules.EXPERIENCE);
    modCon = bcExp.getModule(brightcove.api.modules.APIModules.CONTENT);
    //modExp.addEventListener(BCExperienceEvent.TEMPLATE_READY, onTemplateReady);
//alert("FIN_LOAD");
//console.log("FIN_LOAD");
}

onTemplateReady = function (evt) {
//alert("INICIO_READY");
//console.log("INICIO_READY");
    modVP.addEventListener(brightcove.api.events.MediaEvent.ERROR, onMediaError);
    modVP.addEventListener(brightcove.api.events.MediaEvent.BEGIN, onMediaBegin);
    modVP.addEventListener(brightcove.api.events.MediaEvent.CHANGE, onMediaChange);
    modVP.addEventListener(brightcove.api.events.MediaEvent.COMPLETE, onMediaComplete);
    modVP.addEventListener(brightcove.api.events.MediaEvent.PLAY, onMediaPlay);
    modVP.addEventListener(brightcove.api.events.MediaEvent.PROGRESS, onMediaProgress);
    modVP.addEventListener(brightcove.api.events.MediaEvent.SEEK_NOTIFY, onMediaSeekNotify);
    modVP.addEventListener(brightcove.api.events.MediaEvent.STOP, onMediaStop);
//console.log("INICIO CARGANDO VIDEO: " + nextVideo + " IdVideo: " + videos[nextVideo]); 
    modVP.loadVideoByID(videos[nextVideo]); 
    //modVP.loadVideoByReferenceID(videos[nextVideo]);  
//	console.log("FIN CARGANDO VIDEO: " + nextVideo + " IdVideo: " + videos[nextVideo]); 
//alert("FIN_READY");
//console.log("FIN_READY");
}

function onMediaError(evt) {
//	alert("INICIO_ERROR");
//console.log("INICIO_ERROR"); 
    // An error has occurred. This is either the stream not yet ready or a transient error.
//    console.log("ERROR:type: " + evt.type);
//    console.log("ERROR:errorType: " + evt.errorType)
//    console.log("ERROR:code: " + evt.code);
//    console.log("ERROR:info: " + evt.info);
//    console.log("FIN_ERROR"); 
    // If an error is fired very soon afterwards, ignore it
    if (Date.now() - errorTime > 500) {
//    	console.log("ADD TIMEOUT FOR READDING PLAYER. retryTime:" + retryTime);
       	if (typeof videos !== 'undefined' && videos.length > 1) {
       		jQuery("#photo-"+playerVideo_idDivModal+"-modal").html("<div style='color:#FFFFFF;'><b><center><br>Emisión en directo con problemas, <br>espere un momento por favor...<br></center></b></div>");
	       	window.setTimeout(function () {
	        									nextVideo = (nextVideo == 0) ? ++nextVideo : --nextVideo;
	        									opciones = eval(playerVideo_opciones);
	        								    opciones.idVideo = videos[nextVideo];
	        									openVideo(opciones);
	        							  }
	        							  , retryTime
	        				  );
		}
    }else {
//        console.log("DOUBLE EVENT IGNORED");
    }
    errorTime = Date.now();
//    alert("FIN_ERROR");
//console.log("FIN_ERROR");
}

function onContentLoad(evt) {
//console.log("INICIO_CONTENT_LOAD");
	/*
    console.log("INICIO CONTENT_LOAD");
    var currentVideo = modVP.getCurrentVideo();
    console.log("INFO: Currently Loaded videoID: " + currentVideo.id);
    modCon.getMediaAsynch(1488633950);
    console.log("FIN CONTENT_LOAD");
    */
//console.log("FIN_CONTENT_LOAD");
}
function onVideoLoad(evt) {
//console.log("INICIO_VIDEO_LOAD");
	/*
    console.log("INICIO VIDEO_LOAD");
    // Reproducir el vídeo recién cargado
    modVP.loadVideo(evt.video.id);
 	console.log("FIN VIDEO_LOAD");
 	*/
//console.log("FIN_VIDEO_LOAD");
}
function onMediaBegin(evt) {
//console.log("INICIO_BEGIN");
    // Playback has begun, remove the overlay
    //overlayElem.style.display = "none";
    // If we get an error once playback starts (like an CDN server problem), we'd want to try reconnecting more quickly
    //retryTime = 1000;
    // And the message shown will be different
    //messageElem.innerHTML = "Por favor espere...";
    // Set event handler for complete - when the stream is finished
    //modVP.addEventListener(BCMediaEvent.COMPLETE, onComplete);
//console.log("FIN_BEGIN");
}
function onMediaChange(evt) {
//console.log("INICIO_CHANGE");
//console.log("FIN_CHANGE");
}
function onMediaComplete(evt) {
//console.log("INICIO_COMPLETE");
	if (typeof videos !== 'undefined' && videos.length > 1) {
		jQuery("#photo-"+playerVideo_idDivModal+"-modal").html("<div style='color:#FFFFFF;'><b><center><br>Emisión en directo con problemas, <br>espere un momento por favor...<br></center></b></div>");
		window.setTimeout(function () {
										/*
										nextVideo = (nextVideo == 0) ? ++nextVideo : --nextVideo;
										opciones.idVideo = videos[nextVideo];
										openVideo(opciones);
										*/
										//console.log("COMPLETE: CONTROL CUANDO TENEMOS VIDEO ALTERNATIVO");
										nextVideo = (nextVideo == 0) ? ++nextVideo : --nextVideo;
										opciones = eval(playerVideo_opciones);
									    opciones.idVideo = videos[nextVideo];
										openVideo(opciones);
										//console.log("FINCOMPLETE: CONTROL CUANDO TENEMOS VIDEO ALTERNATIVO");
									  }
		        					  , retryTime
		        				  );
	}
//console.log("FIN_COMPLETE");
}
function onMediaPlay(evt) {
//console.log("INICIO_PLAY");
//console.log("FIN_PLAY");
}
function onMediaProgress(evt) {
//console.log("INICIO_PROGRESS");
//console.log("FIN_PROGRESS");
}
function onMediaSeekNotify(evt) {
//console.log("INICIO_SEEK_NOTIFY");
//console.log("FIN_SEEK_NOTIFY");
}
function onMediaStop(evt) {
//console.log("INICIO_STOP");
//console.log("FIN_STOP");
}
/*NEW PLAYER*/

function mandarOAS() {

	if(typeof OAS_sitepage=="undefined"){
	
		OAS_sitepage = '';
	
	}

	return getOAS_sitepage(OAS_sitepage);
}
/**
  Obtiene el OAS Site Page correcto en función del valor de la variable que tiene esta pagina
*/
function getOAS_sitepage(sOAS_sitepage) {

	if (sOAS_sitepage!=''){

		var campos = sOAS_sitepage.split('/');		
		var campos2 = campos[0].split('.');
		
		switch (campos2[1]) {
			case 'elcomercio-sa':
				var periodico = 'elcomerciodigital';
				break;
			case 'elcomercio':
				var periodico = 'elcomerciodigital';
				break;
			case 'elnortedecastilla':
				var periodico = 'nortecastilla';
				break;
			case 'diario-elcorreo':
				var periodico = 'elcorreodigital';
				break;
			case 'la-verdad':
				var periodico = 'laverdad';
				break;
			case 'lavozdecadiz':
				var periodico = 'lavozdigital';
				break;
			default:
				var periodico = campos2[1];
				break;	
		}
		
		//var ediciones = new Array('alava', 'vizcaya', 'aviles', 'gijon', 'oviedo', 'almeria', 'granada', 'jaen', 'alicante', 'valencia', 'albacete', 'murcia', 'cadiz', 'jerez', 'castellon');		
		var separador = '/';	
		var respuesta = 'vocento.' + periodico;
		var cont = 1;
		while( campos[cont] != null )
		{
			respuesta += separador + campos[cont];
			cont++;	
		}
		
		
		/*
		OAS PARA INSKIN
		vocento.abc
		vocento.abcdesevilla
		vocento.diariosur
		vocento.elcomerciodigital
		vocento.elcorreodigital
		vocento.eldiariomontanes
		vocento.diariovasco
		vocento.hoy
		vocento.ideal
		vocento.larioja
		vocento.lasprovincias
		vocento.laverdad
		vocento.lavozdigital
		vocento.nortecastilla	
		
		añadido por jsj, si un video muestra capa modal y tiene alguno de esos valores en el OAS ha de cargar el player con el OAS
		*/
		
		//!!!!COMENTADO PARA QUITAR INSKIN EN PPLL
		/*
		if (respuesta.indexOf('vocento.abc')!=-1 || respuesta.indexOf('vocento.abcdesevilla')!=-1 || respuesta.indexOf('vocento.diariosur')!=-1 
			|| respuesta.indexOf('vocento.elcomerciodigital')!=-1 || respuesta.indexOf('vocento.eldiariomontanes')!=-1 || respuesta.indexOf('vocento.elcorreodigital')!=-1 
			|| respuesta.indexOf('vocento.diariovasco')!=-1 || respuesta.indexOf('vocento.hoy')!=-1 || respuesta.indexOf('vocento.ideal')!=-1
			|| respuesta.indexOf('vocento.larioja')!=-1 || respuesta.indexOf('vocento.lasprovincias')!=-1 || respuesta.indexOf('vocento.laverdad')!=-1 
			|| respuesta.indexOf('vocento.lavozdigital')!=-1 || respuesta.indexOf('vocento.nortecastilla')!=-1) {

			//cargamos inskin en capa modal
			//alert (respuesta + "SKIN!");
			inSkin = true;
		}
		
		// INSKIN no debe aparecer cuando se trata de un dispositivo movil
		if(DetectMobileLonger()){
			inSkin = false;
		}*/
				
		// FIN DE COMENTADO PARA QUITAR INSKIN EN PPLL
		
		return respuesta;
		
	}else{
	
		return '';
		
	}

}

function mandarOASJS() {
	if(typeof OAS_sitepage=="undefined"){
		OAS_sitepage = '';
	}
return "mandarOAS" + getOAS_sitepage(OAS_sitepage);
}

//modificado por JSJ, da problemas en IE8 el addEventListener y como es solo para móviles se quita para cualquier IE
if (navigator && navigator.appName && navigator.appName != "Microsoft Internet Explorer") {

	window.addEventListener('message', function(e) {
		if (e.data == 'mandarOASJS') {
			e.source.postMessage(String(mandarOASJS()), e.origin);
		}
	}, false);
	
	//console.log ("NO IE");

}	else {

	//console.log ("SI IE");

}

/**
 * Constructor
 */
function PlayerWebTV() {
	this.initted = false;
	this.portal = null;
	this.mosca  = null;
	this.rutaConfig  = null;
}

// ************************************************************************
// ******************  CONSTANTES *****************************************
//************************************************************************
PlayerWebTV.MIN_ANCHO_PLAYER = 180;
PlayerWebTV.MIN_ALTO_PLAYER = 100;
PlayerWebTV.BASE_CONFIG  = "/includes/manuales/swf/playerWebTV/";
PlayerWebTV.VERSION_FLASH  = 8;

/**
 * CTES identificadoras de los portales
 */
PlayerWebTV.IDS_PORTALES = {
	ABC: "abc",
	ABC_SEVILLA: "abcdesevilla",
	NORTE_CASTILLA: "nortecastilla",
	NORTE_CASTILLA_2011: "elnortedecastilla",
	LA_VOZ: "lavozdigital",
	DIARIO_MONTANES: "eldiariomontanes",
	DIARIO_SUR: "diariosur",
	DIARIO_VASCO: "diariovasco",
	EL_COMERCIO: "elcomerciodigital",
	EL_COMERCIO_2011: "elcomercio",
	EL_CORREO: "elcorreo",
	EL_CORREODIGITAL: "elcorreodigital",
	HOY: "hoy",
	IDEAL: "ideal",
	LA_RIOJA: "larioja",
	LA_VERDAD: "laverdad",
	LAS_PROVINCIAS: "lasprovincias",
	SUR_INGLES:	"sureng",
	QUE: "que",
	ABC_F1: "abc_f1",
	ABC_SEVILLA_F1: "abcdesevilla_f1",
	NORTE_CASTILLA_F1: "nortecastilla_f1",
	LA_VOZ_F1: "lavozdigital_f1",
	DIARIO_MONTANES_F1: "eldiariomontanes_f1",
	DIARIO_SUR_F1: "diariosur_f1",
	DIARIO_VASCO_F1: "diariovasco_f1",
	EL_COMERCIO_F1: "elcomerciodigital_f1",
	EL_CORREO_F1: "elcorreo_f1",
	EL_CORREODIGITAL_F1: "elcorreodigital_f1",
	HOY_F1: "hoy_f1",
	IDEAL_F1: "ideal_f1",
	LA_RIOJA_F1: "larioja_f1",
	LA_VERDAD_F1: "laverdad_f1",
	LAS_PROVINCIAS_F1: "lasprovincias_f1",
	ABC_FUTBOL_LOCO: "abc_futbol_loco",
	ABC_SEVILLA_FUTBOL_LOCO: "abcsevilla_futbol_loco",
	NORTE_CASTILLA_FUTBOL_LOCO: "nortecastilla_futbol_loco",
	NORTE_CASTILLA_2011_FUTBOL_LOCO: "elnortedecastilla_futbol_loco",
	LA_VOZ_FUTBOL_LOCO: "lavoz_futbol_loco",
	DIARIO_MONTANES_FUTBOL_LOCO: "eldiariomontanes_futbol_loco",
	DIARIO_SUR_FUTBOL_LOCO: "diariosur_futbol_loco",
	DIARIO_VASCO_FUTBOL_LOCO: "diariovasco_futbol_loco",
	EL_COMERCIO_FUTBOL_LOCO: "elcomercio_futbol_loco",
	EL_CORREO_FUTBOL_LOCO: "elcorreo_futbol_loco",
	EL_CORREODIGITAL_FUTBOL_LOCO: "elcorreodigital_futbol_loco",
	HOY_FUTBOL_LOCO: "hoy_futbol_loco",
	IDEAL_FUTBOL_LOCO: "ideal_futbol_loco",
	LA_RIOJA_FUTBOL_LOCO: "larioja_futbol_loco",
	LA_VERDAD_FUTBOL_LOCO: "laverdad_futbol_loco",
	LAS_PROVINCIAS_FUTBOL_LOCO: "lasprovincias_futbol_loco",
	HOYCINEMA_FUTBOL_LOCO: "hoycinema_futbol_loco",
	HOYMUJER_FUTBOL_LOCO: "hoymujer_futbol_loco",
	FINANZAS_FUTBOL_LOCO: "finanzas_futbol_loco",
	QUE_FUTBOL_LOCO: "que_futbol_loco"
	
};

/**
 * Contador para retrasar la carga de multiples videos a la vez en IExplorer
 */
PlayerWebTV.ieCounter = 1;

/**
 * entorno en el que nos encontramos
 */
PlayerWebTV.entorno = getEntorno();

//TODO: faltan mas configuraciones de portales
/**
 * Informacion de los portales
 */
PlayerWebTV.INFO_PORTALES = {};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.ABC] = {
	"resizer": "abc.es",
	"servidores": ["abc.es", "http://212.81.129.25:8280", "http://212.81.129.25", "http://preproduccionabc.abc.es"],
	"dominio": PlayerWebTV.entorno,
	"idPlayerINSKIN": "1158356463001",
	"baseConfig": "/swf/playerWebTV/"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.ABC_SEVILLA] = {
	"resizer": "abc.es",
	"servidores": ["abcdesevilla.es", "http://212.81.129.25:8281", "http://212.81.129.25", "http://preproduccionsevilla.abc.es"],
	"dominio": PlayerWebTV.entorno,
	"idPlayerINSKIN": "1158356463001",
	"baseConfig": "/swf/playerWebTV/"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.QUE] = {
	"resizer": "que.es",
	"servidores": [PlayerWebTV.entorno + ".que.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".que.es",
	"idPlayer": "66035019001",
	"idPlayerSinPublicidad": "66035019001",
	"idPlayerINSKIN": "1386764378001",
	"idPublisher": "85688292001",
	"medio": "QUE"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.NORTE_CASTILLA] = {
	"resizer": "nortecastilla.es",
	"servidores": [PlayerWebTV.entorno + ".nortecastilla.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".nortecastilla.es",
	"idPlayer": "292158289001",
	"idPlayerSinPublicidad": "661006236001",
	"idPlayerINSKIN": "1173939816001",
	"idPublisher": "86746486001",
	"medio": "NORCAS"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.NORTE_CASTILLA_2011] = {
		"resizer": "elnortedecastilla.es",
		"servidores": [PlayerWebTV.entorno + ".elnortedecastilla.es"],
		"dominio": "http://" + PlayerWebTV.entorno + ".elnortedecastilla.es",
		"idPlayer": "292158289001",
		"idPlayerSinPublicidad": "661006236001",
		"idPlayerINSKIN": "1173939816001",
		"idPublisher": "86746486001",
		"medio": "NORCAS"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.LA_VOZ] = {
	"resizer": "lavozdigital.es",
	"servidores": [PlayerWebTV.entorno + ".lavozdigital.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".lavozdigital.es",
	"idPlayer": "292326712001",
	"idPlayerSinPublicidad": "660958362001",
	"idPlayerINSKIN": "1174938233001",
	"idPublisher": "86847173001",
	"medio": "VOZCAD"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.DIARIO_MONTANES] = {
	"resizer": "eldiariomontanes.es",
	"servidores": [PlayerWebTV.entorno + ".eldiariomontanes.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".eldiariomontanes.es",
	"idPlayer": "308992240001",
	"idPlayerSinPublicidad": "660562415001",
	"idPlayerINSKIN": "1174938200001",
	"idPublisher": "85707285001",
	"medio": "DIAMON"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.DIARIO_SUR] = {
	"resizer": "diariosur.es",
	"servidores": [PlayerWebTV.entorno + ".diariosur.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".diariosur.es",
	"idPlayer": "309045659001",
	"idPlayerSinPublicidad": "660562414001",
	"idPlayerINSKIN": "1174782757001",
	"idPublisher": "85688293001",
	"medio": "SUR"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.SUR_INGLES] = {
	"resizer": "surinenglish.com",
	"servidores": [PlayerWebTV.entorno + ".surinenglish.com"],
	"dominio": "http://" + PlayerWebTV.entorno + ".surinenglish.com",
	"idPlayer": "309045659001",
	"idPlayerSinPublicidad": "309045659001",
	"idPlayerINSKIN": "1174782757001",
	"idPublisher": "85688293001",
	"medio": "SURENG"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.DIARIO_VASCO] = {
	"resizer": "diariovasco.com",
	"servidores": [PlayerWebTV.entorno + ".diariovasco.com"],
	"dominio": "http://" + PlayerWebTV.entorno + ".diariovasco.com",
	"idPlayer": "292369646001",
	"idPlayerSinPublicidad": "660588367001",
	"idPlayerINSKIN": "1170996395001",
	"idPublisher": "85688294001",
	"medio": "DIAVAS"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.EL_COMERCIO] = {
	"resizer": "elcomerciodigital.com",
	"servidores": [PlayerWebTV.entorno + ".elcomerciodigital.com"],
	"dominio": "http://" + PlayerWebTV.entorno + ".elcomerciodigital.com",
	"idPlayer": "308992247001",
	"idPlayerSinPublicidad": "660958355001",
	"idPlayerINSKIN": "1174782758001",
	"idPublisher": "85707284001",
	"medio": "COMERC"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.EL_COMERCIO_2011] = {
		"resizer": "elcomercio.es",
		"servidores": [PlayerWebTV.entorno + ".elcomercio.es"],
		"dominio": "http://" + PlayerWebTV.entorno + ".elcomercio.es",
		"idPlayer": "308992247001",
		"idPlayerSinPublicidad": "660958355001",
		"idPlayerINSKIN": "1174782758001",
		"idPublisher": "85707284001",
		"medio": "COMERC"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.EL_CORREO] = {
	"resizer": "elcorreo.com",
	"servidores": [PlayerWebTV.entorno + ".elcorreo.com"],
	"dominio": "http://" + PlayerWebTV.entorno + ".elcorreo.com",
	"idPlayer": "309018193001",
	"idPlayerSinPublicidad": "661006233001",
	"idPlayerINSKIN": "1158356463001",
	"idPublisher": "85688292001",
	"medio": "CORREO"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.EL_CORREODIGITAL] = {
	"resizer": "elcorreo.com",
	"servidores": [PlayerWebTV.entorno + ".elcorreo.com"],
	"dominio": "http://" + PlayerWebTV.entorno + ".elcorreo.com",
	"idPlayer": "309018193001",
	"idPlayerSinPublicidad": "661006233001",
	"idPlayerINSKIN": "1158356463001",
	"idPublisher": "85688292001",
	"medio": "CORREO"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.HOY] = {
	"resizer": "hoy.es",
	"servidores": [PlayerWebTV.entorno + ".hoy.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".hoy.es",
	"idPlayer": "309010012001",
	"idPlayerSinPublicidad": "661006227001",
	"idPlayerINSKIN": "1170996396001",
	"idPublisher": "85688295001",
	"medio": "HOY"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.IDEAL] = {
	"resizer": "ideal.es",
	"servidores": [PlayerWebTV.entorno + ".ideal.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".ideal.es",
	"idPlayer": "309010008001",
	"idPlayerSinPublicidad": "661006234001",
	"idPlayerINSKIN": "1173939812001",
	"idPublisher": "86746483001",
	"medio": "IDEALM"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.LA_RIOJA] = {
	"resizer": "larioja.com",
	"servidores": [PlayerWebTV.entorno + ".larioja.com"],
	"dominio": "http://" + PlayerWebTV.entorno + ".larioja.com",
	"idPlayer": "309010007001",
	"idPlayerSinPublicidad": "660958361001",
	"idPlayerINSKIN": "1170996397001",
	"idPublisher": "86746484001",
	"medio": "RIOJA"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.LA_VERDAD] = {
	"resizer": "laverdad.es",
	"servidores": [PlayerWebTV.entorno + ".laverdad.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".laverdad.es",
	"idPlayer": "292369619001",
	"idPlayerSinPublicidad": "661006235001",
	"idPlayerINSKIN": "1174938202001",
	"idPublisher": "85707286001",
	"medio": "VERMUR",
	"dominio2": "http://" + PlayerWebTV.entorno + ".lasprovincias.es"
		
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.LAS_PROVINCIAS] = {
	"resizer": "lasprovincias.es",
	"servidores": [PlayerWebTV.entorno + ".lasprovincias.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".lasprovincias.es",
	"idPlayer": "308992236001",
	"idPlayerSinPublicidad": "660588370001",
	"idPlayerINSKIN": "1173939814001",
	"idPublisher": "86746485001",
	"medio": "PROVAL",
	"dominio2": "http://" + PlayerWebTV.entorno + ".laverdad.es"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.ABC_F1] = {
	"resizer": "abc.es",
	"servidores": ["abc.es", "http://212.81.129.25:8280", "http://212.81.129.25", "http://preproduccionabc.abc.es"],
	"dominio": PlayerWebTV.entorno,
	"baseConfig": "/swf/playerWebTV/"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.ABC_SEVILLA_F1] = {
	"resizer": "abc.es",
	"servidores": ["abcdesevilla.es", "http://212.81.129.25:8281", "http://212.81.129.25", "http://preproduccionsevilla.abc.es"],
	"dominio": PlayerWebTV.entorno,
	"baseConfig": "/swf/playerWebTV/"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.NORTE_CASTILLA_F1] = {
	"resizer": "nortecastilla.es",
	"servidores": [PlayerWebTV.entorno + ".nortecastilla.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".nortecastilla.es",
	"idPlayer": "292158289001",
	"idPlayerSinPublicidad": "292158289001",
	"idPublisher": "86746486001",
	"medio": "NORCAS"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.LA_VOZ_F1] = {
	"resizer": "lavozdigital.es",
	"servidores": [PlayerWebTV.entorno + ".lavozdigital.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".lavozdigital.es",
	"idPlayer": "292326712001",
	"idPlayerSinPublicidad": "292326712001",
	"idPublisher": "86847173001",
	"medio": "VOZCAD"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.DIARIO_MONTANES_F1] = {
	"resizer": "eldiariomontanes.es",
	"servidores": [PlayerWebTV.entorno + ".eldiariomontanes.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".eldiariomontanes.es",
	"idPlayer": "308992240001",
	"idPlayerSinPublicidad": "308992240001",
	"idPublisher": "85707285001",
	"medio": "DIAMON"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.DIARIO_SUR_F1] = {
	"resizer": "diariosur.es",
	"servidores": [PlayerWebTV.entorno + ".diariosur.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".diariosur.es",
	"idPlayer": "309045659001",
	"idPlayerSinPublicidad": "309045659001",
	"idPublisher": "85688293001",
	"medio": "SUR"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.SUR_INGLES_F1] = {
	"resizer": "surinenglish.com",
	"servidores": [PlayerWebTV.entorno + ".surinenglish.com"],
	"dominio": "http://" + PlayerWebTV.entorno + ".surinenglish.com",
	"idPlayer": "309045659001",
	"idPlayerSinPublicidad": "309045659001",
	"idPublisher": "85688293001",
	"medio": "SURENG"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.DIARIO_VASCO_F1] = {
	"resizer": "diariovasco.com",
	"servidores": [PlayerWebTV.entorno + ".diariovasco.com"],
	"dominio": "http://" + PlayerWebTV.entorno + ".diariovasco.com",
	"idPlayer": "292369646001",
	"idPlayerSinPublicidad": "292369646001",
	"idPublisher": "85688294001",
	"medio": "DIAVAS"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.EL_COMERCIO_F1] = {
	"resizer": "elcomerciodigital.com",
	"servidores": [PlayerWebTV.entorno + ".elcomerciodigital.com"],
	"dominio": "http://" + PlayerWebTV.entorno + ".elcomerciodigital.com",
	"idPlayer": "308992247001",
	"idPlayerSinPublicidad": "308992247001",
	"idPublisher": "85707284001",
	"medio": "COMERC"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.EL_CORREO_F1] = {
	"resizer": "elcorreo.com",
	"servidores": [PlayerWebTV.entorno + ".elcorreo.com"],
	"dominio": "http://" + PlayerWebTV.entorno + ".elcorreo.com",
	"idPlayer": "309018193001",
	"idPlayerSinPublicidad": "309018193001",
	"idPublisher": "85688292001",
	"medio": "CORREO"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.EL_CORREODIGITAL_F1] = {
	"resizer": "elcorreo.com",
	"servidores": [PlayerWebTV.entorno + ".elcorreo.com"],
	"dominio": "http://" + PlayerWebTV.entorno + ".elcorreo.com",
	"idPlayer": "309018193001",
	"idPlayerSinPublicidad": "309018193001",
	"idPublisher": "85688292001",
	"medio": "CORREO"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.HOY_F1] = {
	"resizer": "hoy.es",
	"servidores": [PlayerWebTV.entorno + ".hoy.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".hoy.es",
	"idPlayer": "309010012001",
	"idPlayerSinPublicidad": "309010012001",
	"idPublisher": "85688295001",
	"medio": "HOY"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.IDEAL_F1] = {
	"resizer": "ideal.es",
	"servidores": [PlayerWebTV.entorno + ".ideal.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".ideal.es",
	"idPlayer": "309010008001",
	"idPlayerSinPublicidad": "309010008001",
	"idPublisher": "86746483001",
	"medio": "IDEALM"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.LA_RIOJA_F1] = {
	"resizer": "larioja.com",
	"servidores": [PlayerWebTV.entorno + ".larioja.com"],
	"dominio": "http://" + PlayerWebTV.entorno + ".larioja.com",
	"idPlayer": "309010007001",
	"idPlayerSinPublicidad": "309010007001",
	"idPublisher": "86746484001",
	"medio": "RIOJA"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.LA_VERDAD_F1] = {
	"resizer": "laverdad.es",
	"servidores": [PlayerWebTV.entorno + ".laverdad.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".laverdad.es",
	"idPlayer": "292369619001",
	"idPlayerSinPublicidad": "292369619001",
	"idPublisher": "85707286001",
	"medio": "VERMUR",
	"dominio2": "http://" + PlayerWebTV.entorno + ".lasprovincias.es"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.LAS_PROVINCIAS_F1] = {
	"resizer": "lasprovincias.es",
	"servidores": [PlayerWebTV.entorno + ".lasprovincias.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".lasprovincias.es",
	"idPlayer": "308992236001",
	"idPlayerSinPublicidad": "308992236001",
	"idPublisher": "86746485001",
	"medio": "PROVAL",
	"dominio2": "http://" + PlayerWebTV.entorno + ".laverdad.es"
};

//PPVV Y QUE PARA LOCOS POR EL FUTBOL

PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.HOYCINEMA_FUTBOL_LOCO] = {
	"resizer": "elcorreo.com",
	"servidores": [PlayerWebTV.entorno + ".elcorreo.com"],
	"dominio": "http://" + PlayerWebTV.entorno + ".elcorreo.com",
	"idPlayer": "903455318001",
	"idPlayerSinPublicidad": "903455318001",
	"idPublisher": "85688292001",
	"medio": "CORREO"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.HOYMUJER_FUTBOL_LOCO] = {
	"resizer": "elcorreo.com",
	"servidores": [PlayerWebTV.entorno + ".elcorreo.com"],
	"dominio": "http://" + PlayerWebTV.entorno + ".elcorreo.com",
	"idPlayer": "903502981001",
	"idPlayerSinPublicidad": "903502981001",
	"idPublisher": "85688292001",
	"medio": "CORREO"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.FINANZAS_FUTBOL_LOCO] = {
	"resizer": "elcorreo.com",
	"servidores": [PlayerWebTV.entorno + ".elcorreo.com"],
	"dominio": "http://" + PlayerWebTV.entorno + ".elcorreo.com",
	"idPlayer": "903502982001",
	"idPlayerSinPublicidad": "903502982001",
	"idPublisher": "85688292001",
	"medio": "CORREO"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.QUE_FUTBOL_LOCO] = {
	"resizer": "elcorreo.com",
	"servidores": [PlayerWebTV.entorno + ".elcorreo.com"],
	"dominio": "http://" + PlayerWebTV.entorno + ".elcorreo.com",
	"idPlayer": "903445518001",
	"idPlayerSinPublicidad": "903445518001",
	"idPublisher": "85688292001",
	"medio": "CORREO"
};

//LOCOS POR EL FUTBOL
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.EL_CORREO_FUTBOL_LOCO] = {
	"resizer": "elcorreo.com",
	"servidores": [PlayerWebTV.entorno + ".elcorreo.com"],
	"dominio": "http://" + PlayerWebTV.entorno + ".elcorreo.com",
	"idPlayer": "904581062001",
	"idPlayerSinPublicidad": "904581062001",
	"idPublisher": "85688292001",
	"medio": "CORREO"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.EL_CORREODIGITAL_FUTBOL_LOCO] = {
	"resizer": "elcorreo.com",
	"servidores": [PlayerWebTV.entorno + ".elcorreo.com"],
	"dominio": "http://" + PlayerWebTV.entorno + ".elcorreo.com",
	"idPlayer": "904581062001",
	"idPlayerSinPublicidad": "904581062001",
	"idPublisher": "85688292001",
	"medio": "CORREO"
};

PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.ABC_FUTBOL_LOCO] = {
	"resizer": "abc.es",
	"servidores": ["abc.es"],
	"dominio": PlayerWebTV.entorno,
	"idPlayer": "903084223001",
	"idPlayerSinPublicidad": "903084223001",
	"idPublisher": "85688292001",
	"medio": "ABCES"
};

PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.ABC_SEVILLA_FUTBOL_LOCO] = {
	"resizer": "abc.es",
	"servidores": ["abc.es"],
	"dominio": PlayerWebTV.entorno,
	"idPlayer": "903455312001",
	"idPlayerSinPublicidad": "903455312001",
	"idPublisher": "55814260001",
	"medio": "ABCES"
};

PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.NORTE_CASTILLA_FUTBOL_LOCO] = {
	"resizer": "nortecastilla.es",
	"servidores": [PlayerWebTV.entorno + ".nortecastilla.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".nortecastilla.es",
	"idPlayer": "903502979001",
	"idPlayerSinPublicidad": "903502979001",
	"idPublisher": "86746486001",
	"medio": "NORCAS"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.NORTE_CASTILLA_2011_FUTBOL_LOCO] = {
	"resizer": "elnortedecastilla.es",
	"servidores": [PlayerWebTV.entorno + ".elnortedecastilla.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".elnortedecastilla.es",
	"idPlayer": "903502979001",
	"idPlayerSinPublicidad": "903502979001",
	"idPublisher": "86746486001",
	"medio": "NORCAS"
};

PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.LA_VOZ_FUTBOL_LOCO] = {
	"resizer": "lavozdigital.es",
	"servidores": [PlayerWebTV.entorno + ".lavozdigital.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".lavozdigital.es",
	"idPlayer": "903503007001",
	"idPlayerSinPublicidad": "903503007001",
	"idPublisher": "86847173001",
	"medio": "VOZCAD"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.DIARIO_MONTANES_FUTBOL_LOCO] = {
	"resizer": "eldiariomontanes.es",
	"servidores": [PlayerWebTV.entorno + ".eldiariomontanes.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".eldiariomontanes.es",
	"idPlayer": "903503008001",
	"idPlayerSinPublicidad": "903503008001",
	"idPublisher": "85707285001",
	"medio": "DIAMON"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.DIARIO_SUR_FUTBOL_LOCO] = {
	"resizer": "diariosur.es",
	"servidores": [PlayerWebTV.entorno + ".diariosur.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".diariosur.es",
	"idPlayer": "903503009001",
	"idPlayerSinPublicidad": "903503009001",
	"idPublisher": "85688293001",
	"medio": "SUR"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.DIARIO_VASCO_FUTBOL_LOCO] = {
	"resizer": "diariovasco.com",
	"servidores": [PlayerWebTV.entorno + ".diariovasco.com"],
	"dominio": "http://" + PlayerWebTV.entorno + ".diariovasco.com",
	"idPlayer": "903455334001",
	"idPlayerSinPublicidad": "903455334001",
	"idPublisher": "85688294001",
	"medio": "DIAVAS"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.EL_COMERCIO_FUTBOL_LOCO] = {
	"resizer": "elcomercio.es",
	"servidores": [PlayerWebTV.entorno + ".elcomercio.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".elcomercio.es",
	"idPlayer": "903445524001",
	"idPlayerSinPublicidad": "903445524001",
	"idPublisher": "85707284001",
	"medio": "COMERC"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.HOY_FUTBOL_LOCO] = {
	"resizer": "hoy.es",
	"servidores": [PlayerWebTV.entorno + ".hoy.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".hoy.es",
	"idPlayer": "903427145001",
	"idPlayerSinPublicidad": "903427145001",
	"idPublisher": "85688295001",
	"medio": "HOY"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.IDEAL_FUTBOL_LOCO] = {
	"resizer": "ideal.es",
	"servidores": [PlayerWebTV.entorno + ".ideal.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".ideal.es",
	"idPlayer": "903427146001",
	"idPlayerSinPublicidad": "903427146001",
	"idPublisher": "86746483001",
	"medio": "IDEALM"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.LA_RIOJA_FUTBOL_LOCO] = {
	"resizer": "larioja.com",
	"servidores": [PlayerWebTV.entorno + ".larioja.com"],
	"dominio": "http://" + PlayerWebTV.entorno + ".larioja.com",
	"idPlayer": "903503010001",
	"idPlayerSinPublicidad": "903503010001",
	"idPublisher": "86746484001",
	"medio": "RIOJA"
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.LA_VERDAD_FUTBOL_LOCO] = {
	"resizer": "laverdad.es",
	"servidores": [PlayerWebTV.entorno + ".laverdad.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".laverdad.es",
	"idPlayer": "903455335001",
	"idPlayerSinPublicidad": "903455335001",
	"idPublisher": "85707286001",
	"medio": "VERMUR",
	"dominio2": "http://" + PlayerWebTV.entorno + ".lasprovincias.es"
		
};
PlayerWebTV.INFO_PORTALES[PlayerWebTV.IDS_PORTALES.LAS_PROVINCIAS_FUTBOL_LOCO] = {
	"resizer": "lasprovincias.es",
	"servidores": [PlayerWebTV.entorno + ".lasprovincias.es"],
	"dominio": "http://" + PlayerWebTV.entorno + ".lasprovincias.es",
	"idPlayer": "903445525001",
	"idPlayerSinPublicidad": "903445525001",
	"idPublisher": "86746485001",
	"medio": "PROVAL",
	"dominio2": "http://" + PlayerWebTV.entorno + ".laverdad.es"
};



/* 
	Inicio: ARRAY DE TAGS PATROCINADOS
*/
var tagsPatrocinados = ['abc', 'abcdesevilla', 'nortecastilla', 'elnortedecastilla', 'lavozdigital', 'eldiariomontanes', 'diariosur', 'diariovasco', 'elcomerciodigital', 'elcomercio', 'elcorreo', 'elcorreodigital', 'hoy', 'ideal', 'larioja', 'laverdad', 'lasprovincias', 'sureng'];
tagsPatrocinados['abc']	= null;
tagsPatrocinados['abcdesevilla'] = null;
tagsPatrocinados['nortecastilla'] = null;
tagsPatrocinados['elnortedecastilla'] = null;
tagsPatrocinados['lavozdigital'] = null;
tagsPatrocinados['eldiariomontanes'] = null;
tagsPatrocinados['diariosur'] = null;
tagsPatrocinados['diariovasco'] = null;
tagsPatrocinados['elcomerciodigital'] = null;
tagsPatrocinados['elcomercio'] = null;
tagsPatrocinados['elcorreo'] = null;
tagsPatrocinados['elcorreodigital'] = null;
tagsPatrocinados['ideal'] = null;
tagsPatrocinados['larioja'] = null;
tagsPatrocinados['laverdad'] = null;
tagsPatrocinados['lasprovincias'] = null;
tagsPatrocinados['sureng'] = null;
tagsPatrocinados['hoy'] = null;/*['Sociedad', 'nacional'];
	tagsPatrocinados['hoy']['Sociedad'] = {
		"imgPatrocinio": "/img/logo-instanet.gif",
		"urlPatrocinio": "http://www.abc.es/",
		"clickcommand": ""	
	};
	tagsPatrocinados['hoy']['nacional'] = {
		"imgPatrocinio": "/img/logo-instanet.gif",
		"urlPatrocinio": "http://www.hoy.es/",
		"clickcommand": ""	
	};*/
// Fin: ARRAY DE TAGS PATROCINADOS

/**
 * Caché de controladores para el player
 */
PlayerWebTV.cache = {};

//************************************************************************
//******************  METODOS ESTATICOS **********************************
//************************************************************************

/**
 * Obtiene la extension del fichero multimedia
 */
PlayerWebTV.getExtension = function(video) {
	var result = video;
	
	while (result.indexOf('/') != -1) {
		result = result.substring(result.indexOf('/')+1, result.length);
	}
	
	if (result.indexOf('.') != -1) {
		result = result.substring(result.indexOf('.')+1, result.length);
	}
	
	return result;
};

/**
 * Obtiene el entorno en el que nos encontramos
 */
function getEntorno() {
	var result = "www";

	if 		(location.href.indexOf('http://www.abc.es') != -1) result = 'http://www.abc.es';
	else if (location.href.indexOf('http://www.abcdesevilla.es') != -1) result = 'http://www.abcdesevilla.es';
	else if (location.href.indexOf('http://212.81.129.25:8280') != -1) result = 'http://212.81.129.25:8280';
	else if (location.href.indexOf('http://212.81.129.25:8281') != -1) result = 'http://212.81.129.25:8281';
	else if (location.href.indexOf('http://sevilla-origin.abc.es') != -1) result = 'http://www.abcdesevilla.es';
	else if (location.href.indexOf('http://www-origin.abc.es/') != -1) result = 'http://www.abc.es';
	else if (location.href.indexOf('http://n1abc10.abc.es') !=-1) result = 'http://www.abc.es';
	else if (location.href.indexOf('http://n2abc10.abc.es') !=-1) result = 'http://www.abc.es';
	else if (location.href.indexOf('http://n3abc10.abc.es') !=-1) result = 'http://www.abc.es';
	else if (location.href.indexOf('http://n4abc10.abc.es') !=-1) result = 'http://www.abc.es';
	else if (location.href.indexOf('http://preproduccionabc.abc.es') !=-1) result = 'http://www.abc.es';
	else if (location.href.indexOf('http://preproduccionsevilla.abc.es') !=-1) result = 'http://www.abcdesevilla.es';	
	else {		
		try {
			result = location.href.split('/')[2].split('.')[0];
			if ( (result != 'www') && (result != 'desarrollo') && (result != 'rediseno') && (result != 'redisenodev') ) {
				result = 'www';
			}
		} catch (e) {
		}		
	}
	
	return result;
}

/**
 * Comprueba si es ABC Desarrollo
 */
function isDesarrolloABC() {
	var result = false;

	if ( (location.href.indexOf('http://212.81.129.25:8280') != -1)  ||
		 (location.href.indexOf('http://212.81.129.25:8281') != -1) ) {
			result = true;
	}
	
	return result;
}

/**
 * Comprueba si es ABC en cualquier entorno
 */
function isABC() {
	var result = false;

	if ( (location.href.indexOf('http://www.abc.es') != -1)  ||
		 (location.href.indexOf('http://www.abcdesevilla.es') != -1)  ||
		 (location.href.indexOf('http://212.81.129.25:8280') != -1)  ||
		 (location.href.indexOf('http://212.81.129.25:8281') != -1) ||
		 (location.href.indexOf('http://sevilla-origin.abc.es') != -1)  ||
		 (location.href.indexOf('http://www-origin.abc.es/') != -1)  ||
		 (location.href.indexOf('http://n1abc10.abc.es') != -1)  ||
		 (location.href.indexOf('http://n2abc10.abc.es') != -1)  ||
		 (location.href.indexOf('http://n3abc10.abc.es') != -1)  ||
		 (location.href.indexOf('http://n4abc10.abc.es') != -1) ) {
			result = true;
	}
	
	return result;
}

/**
 * Obtiene el color de fondo
 */
function getColorFondo() {
	var colorFondo = '#000000';

	if (isABC()) colorFondo = '#f1f1f1';
	
	return colorFondo;
}

/**
 * Muestra el player cargandolo en la cache de portales
 */
PlayerWebTV.cargaVideo = function(div, sFile, w, h, adOpciones) {
	var funcion = PlayerWebTV.cargaVideo; 
	if (arguments.length < 5) {
		// Si no nos pasan un id de capa, creamos 1 en la posicion actual y la usamos para escribir el video
		// (CUIDADO!  Si la pagina ya esta cargada, siempre hay que indicar un id, sino borraria la pagina actual)
		var uid = this.getUID("video");
		document.write('<div id="' + uid + '"></div>');
		
		var args = new Array(5);
		args[0] = uid;
		for (var i = 0; i < arguments.length; i++) {
			args[i + 1] = arguments[i];
		}
		
		funcion.call(this, args[0], args[1], args[2], args[3], args[4]);
		return;
	}
	
	//Comprobación de las opciones
	var opciones = {
		categoriaPubli: ((adOpciones.categoriaPubli==undefined)?'':adOpciones.categoriaPubli),
		titulo: ((adOpciones.titulo==undefined)?'':adOpciones.titulo),
		imgPrevia: ((adOpciones.imgPrevia==undefined)?'':adOpciones.imgPrevia),
		site: ((adOpciones.site==undefined)?'':adOpciones.site),
		entradilla: ((adOpciones.entradilla==undefined)?'':adOpciones.entradilla),
		urlTitulo: ((adOpciones.urlTitulo==undefined)?'':adOpciones.urlTitulo),
		imgPatrocinio: ((adOpciones.imgPatrocinio==undefined)?'':adOpciones.imgPatrocinio),
		urlPatrocinio: ((adOpciones.urlPatrocinio==undefined)?'':adOpciones.urlPatrocinio),
		clickcommand: ((adOpciones.clickcommand==undefined)?'':adOpciones.clickcommand),
		capaModal: ((adOpciones.capaModal == undefined) ? true : adOpciones.capaModal),
		publicidadOn: ((adOpciones.publicidadOn == undefined) ? true : adOpciones.publicidadOn),
		comentarios: ((adOpciones.comentarios == undefined) ? '' : adOpciones.comentarios),
		redesSociales: (adOpciones.redesSociales == undefined) ? true : adOpciones.redesSociales,
		apoyoTexto: ((adOpciones.apoyoTexto==undefined)?'':adOpciones.apoyoTexto),
		apoyoURL: ((adOpciones.apoyoURL==undefined)?'':adOpciones.apoyoURL),
		antetituloTexto: ((adOpciones.antetituloTexto==undefined)?'':adOpciones.antetituloTexto),
		usoResizer: (adOpciones.usoResizer == undefined) ? true : adOpciones.usoResizer
	};
	var player = null;
	var config = null;
	if (!opciones) {
		opciones = {};
	}
	
	if (opciones) {
		config = opciones.config || opciones.site;
	}
	if (config) {
		config = config.toLowerCase();
	}
	if (config == this.IDS_PORTALES.ABC) {
		var exp = /(sevilla)|(212\.81\.129\.25:8281)/gi;
		if (exp.test(location.host)) {
			config = this.IDS_PORTALES.ABC_SEVILLA;
		}
	} else if (config == "abcsevilla") {
		config = this.IDS_PORTALES.ABC_SEVILLA;
	} else if (config == "sur") {
		config = this.IDS_PORTALES.DIARIO_SUR;
	} else if (config == "diavas") {
		config = this.IDS_PORTALES.DIARIO_VASCO;
	} else if (config == "comerc") {
		config = this.IDS_PORTALES.EL_COMERCIO;
	} else if (config == "correo") {
		config = this.IDS_PORTALES.EL_CORREO;
	} else if (config == "diamon") {
		config = this.IDS_PORTALES.DIARIO_MONTANES;
	} else if (config == "idealm") {
		config = this.IDS_PORTALES.IDEAL;
	} else if (config == "rioja") {
		config = this.IDS_PORTALES.LA_RIOJA;
	} else if (config == "proval") {
		config = this.IDS_PORTALES.LAS_PROVINCIAS;
	} else if (config == "vermur") {
		config = this.IDS_PORTALES.LA_VERDAD;
	} else if (config == "vozcad" || config == "Lavoz" || config == "lavoz") {
		config = this.IDS_PORTALES.LA_VOZ;
	} else if (config == "norcas") {
		config = this.IDS_PORTALES.NORTE_CASTILLA;
	} else if (config == "abc_f1") {
		config = this.IDS_PORTALES.ABC_F1;
	} else if (config == "abcsevilla_f1") {
		config = this.IDS_PORTALES.ABC_SEVILLA_F1;
	} else if (config == "sur_f1") {
		config = this.IDS_PORTALES.DIARIO_SUR_F1;
	} else if (config == "diavas_f1") {
		config = this.IDS_PORTALES.DIARIO_VASCO_F1;
	} else if (config == "comerc_f1") {
		config = this.IDS_PORTALES.EL_COMERCIO_F1;
	} else if (config == "correo_f1") {
		config = this.IDS_PORTALES.EL_CORREO_F1;
	} else if (config == "diamon_f1") {
		config = this.IDS_PORTALES.DIARIO_MONTANES_F1;
	} else if (config == "idealm_f1") {
		config = this.IDS_PORTALES.IDEAL_F1;
	} else if (config == "rioja_f1") {
		config = this.IDS_PORTALES.LA_RIOJA_F1;
	} else if (config == "proval_f1") {
		config = this.IDS_PORTALES.LAS_PROVINCIAS_F1;
	} else if (config == "vermur_f1") {
		config = this.IDS_PORTALES.LA_VERDAD_F1;
	} else if (config == "vozcad_f1" || config == "Lavoz_f1" || config == "lavoz_f1") {
		config = this.IDS_PORTALES.LA_VOZ_F1;
	} else if (config == "norcas_f1") {
		config = this.IDS_PORTALES.NORTE_CASTILLA_F1;
	} else if (config == "ideal_futbol_loco") {
		config = this.IDS_PORTALES.IDEAL_FUTBOL_LOCO;
	}
	
	
	if (!config) {
		player = new PlayerWebTV();
	} else {
		opciones.site = config;
		opciones.config = config;
		if (!PlayerWebTV.cache[config]) {
			PlayerWebTV.cache[config] = new PlayerWebTV();
		}
		player = PlayerWebTV.cache[config];
	}
	
	
	/*if( isVideoBC(sFile) ) {
		player.showVideoBC(div, sFile, w, h, opciones);
	//} else {
		//player.showVideo(div, sFile, w, h, opciones);
	//}*/
	
	//añadido por JSJ para verificar si hay inskin
	var sOA = mandarOAS();
	//
	var extension = PlayerWebTV.getExtension(sFile);
	if ((sFile.indexOf('http://cache1.agilecontents.com') != -1) || (extension == 'mp3')) {
		player.showVideo(div, sFile, w, h, opciones);
	} else {
		player.showVideoBC(div, sFile, w, h, opciones);
	}	
};

/**
 * Funcion utilidad para eliminar eventos
 */
PlayerWebTV.nada = function() {};


/**
 * Obtiene el portal del que cargar su configuracion
 * 
 * Si se indica como parametro, se devuelve ese, en otro caso, se calcula de la URL
 */
PlayerWebTV.getPortal = function(opciones) {
	var result = null;
	
	if (opciones && opciones.site) {
		result = opciones.site;
	} else {
		// Identificación por URL
		var servidor = location.host;

		for (var portal in this.INFO_PORTALES) {
			var servidores = this.INFO_PORTALES[portal].servidores;
			
			for (var i = 0; i < servidores.length; i++) {
				var candidato = servidores[i];
				if (servidor.indexOf(candidato) != -1) {
					result = portal;
					break;
				}
			}
		}
	}
	
	return result;
};





/**
 * Elimina caracteres extraños del titulo
 */
PlayerWebTV.getCleanTitle = function(title) {
	title = title.toLowerCase();
	title = title.replace(/[àáâä]+/g, "a");
	title = title.replace(/[éèêë]+/g, "e");
	title = title.replace(/[ìíîï]+/g, "i");
	title = title.replace(/[óòôö]+/g, "o");
	title = title.replace(/[úùûü]+/g, "u");
	title = title.replace(/[ç]+/g, "c");
	title = title.replace(/ñ/g, "n");
	title = title.replace(/[^ \w]/g, "");
	return title;
};


/**
 * Extrae las palabras clave del titulo
 */
PlayerWebTV.getKeyWords = function(title) {
	var keywords = "";
	if (title) {
		title = title.toLowerCase();
		title = title.replace(/[àáâä]+/g, "a");
		title = title.replace(/[éèêë]+/g, "e");
		title = title.replace(/[ìíîï]+/g, "i");
		title = title.replace(/[óòôö]+/g, "o");
		title = title.replace(/[úùûü]+/g, "u");
		title = title.replace(/[ç]+/g, "c");
		title = title.replace(/[ñ]+/g, "n");
		title = title.replace(/\b/g, "_");
		title = title.replace(/\W/g, "");
		var words = title.split("_");
		var keywords = "";
		for ( var i = 0; i < words.length; i++) {
			if (3 < words[i].length)
				keywords += "," + words[i];
		}
		if (keywords != "") {
			keywords = keywords.substring(1);
		}
	}
	return keywords;
}

/**
 * Elimina caracteres extraños de una URL
 */
PlayerWebTV.cleanURL = function(url) {
	if (url) {
		return url.replace(/[^\w- ]/, "");
	} else {
		return url;
	}
}

/**
 * Genera un identificador unico (se usan 2 numeros aleatorios, ya que varias llamadas consecutivas pueden dar los
 * mismos nanosegundos.
 * @param prefijo Cadena que se contanera al principio del identificador
 * @return prefijo_numAleat_numAleat
 */
PlayerWebTV.getUID = function(prefijo) {
	var result = [new Date().getTime(), Math.ceil(Math.random() * 1000)];
	if (prefijo) {
		result.splice(0, 0, prefijo);
	}
	return result.join("_");
}

//************************************************************************
//******************  METODOS DE CLASE  **********************************
//************************************************************************
PlayerWebTV.prototype = {
	/**
	 * Inicializa el player cn la configuración pasada como parametro
	 */
	init: function(opciones, video) {
		var rutaConfig = null;
		
		// Intentamos calcular el portal desde el que se carga la libreria
		var portal = this.portal;
		if (!this.portal) {
			portal = this.portal = this.getPortal(opciones);
		}
		
		var config = null;
		
		if (opciones) {
			config = opciones.config || portal;
		}
		
		if (!this.rutaConfig) {
			var extension = PlayerWebTV.getExtension(video);
			var rutaConfig;
			if (extension == 'mp3') {
				rutaConfig = "config-por-defecto-audio.xml";
				if (config) {
					rutaConfig = "config-" + config + "-audio.xml";
				}
			}
			else {
				rutaConfig = "config-por-defecto.xml";
				if (config) {
					rutaConfig = "config-" + config + ".xml";
				}
			}			
			
			this.rutaConfig = this.getURLBase("config/" + rutaConfig);
		}
		
		if (!this.mosca) {
			// Mosca
			this.mosca = {
				url: "",
				ancho: -1,
				alto: -1,
				img: null
			};
		}
	
		if (config) {
			if (!this.mosca.img) {
				this.mosca.img = new Image();
				var urlMosca = this.getURLBase("imagenes/" + config + "/mosca.png");
				this.mosca.img.src = this.mosca.url = urlMosca;
				var moscaImg = this.mosca.img;
				
				var _this = this;
				if (moscaImg.complete) {
					_this.cargarConfigMosca(moscaImg);
				} else {
					if (!moscaImg.onload) {
						moscaImg.onload = function() {
							_this.cargarConfigMosca(moscaImg);
						}
						moscaImg.onabort = moscaImg.onerror = function() {
							_this.initted = true;
						}
					}
				}
			}
		} else {
			this.initted = true;
		}
		
		return this.initted;
	},
	
	cargarConfigMosca : function(logo) {
		this.mosca.ancho = parseInt(logo.width, 10);
		this.mosca.alto = parseInt(logo.height, 10);
		
		this.initted = true;
	},
	
	calculaMosca: function(ancho, alto) {
		try {
			var config = this.mosca;
			var mosca = "mosca.png";
			var iAncho = parseInt(ancho, 10);
			var iAlto = parseInt(alto, 10);
			
			var altoMosca = config.alto;
			var anchoMosca = config.ancho;
			
			if ((iAncho * 0.5) < anchoMosca || (iAlto * 0.3) < altoMosca) {
				mosca = "mosca-small.png";
			}
			
			if (iAncho < this.MIN_ANCHO_PLAYER || iAlto < this.MIN_ALTO_PLAYER) {
				mosca = "";
			}
			
			if (mosca) {
				return config.url.substring(0, config.url.lastIndexOf("/") + 1) + mosca;
			} else {
				return "";
			}
		} catch (e) {
			return "";
		}
	},
	/*
	utmac	UA-6773806-3
	utmcc	__utma=65922302.2025355597012597800.1252482418.1253875116.1255016623.18;+__utmz=65922302.1253699542.12.2.utmcsr=212.81.129.25:8281|utmccn=(referral)|utmcmd=referral|utmcct=/index.asp;
	utmcs	UTF-8
	utmdt	ABC WEB TV
	utme	5(video*Video servido*abctv._gente.en-abctv.Indios y Vaqueros: Alondra Bentley)
	utmfl	10.0 r32
	utmhid	1273621659
	utmhn	www.abctv.es
	utmje	0
	utmn	343073796
	utmp	/
	utmr	-
	utmsc	32-bit
	utmsr	1280x800
	utmt	event
	utmul	es-es
	utmwv	4.3as
	 */
	setValoresGoogleAnalytics : function(fo, opciones) {
		var categorias = this.getCategoriasGoogleAnalytics(opciones);
		var result = [];
		result.push("channel::" + categorias[0]);
		result.push("subChannel::" + categorias[1]);
		fo.addVariable("googleAnalytics", result.join(","));
	},
		
	getCategoriasGoogleAnalytics : function(opciones) {
		var categoria = "";
		var subcategoria = "";
		
		try {
			if (this.esDominioConocido()) {
				var url = location.pathname;
				var partes = url.split("/");
				
				// eliminamos la 1ª pq siempre llega vacia
				partes.splice(0, 1);
				
				if (partes[partes.length - 1] == "") {
					// comprobamos si la ultima partes es vacia
					partes.splice(partes.length - 1, 1);
				}
				
				if (partes.length > 0) {
					if (/^\d{8}/.test(partes[0])) {
						// la 1ª componente es 1 fecha, luego es un detalle de noticia
						// la eliminamos
						partes.splice(0, 1);
					}
				}
				if (partes.length > 0) {
					if (partes[partes.length - 1].indexOf(".") != -1) {
						if (partes[partes.length - 1].indexOf(".asp") != -1) {
							// si acaba en asp es una portada de ABC, la preparamos para intentar sacar luego la subcategoria
							var paginaTemp = partes[partes.length - 1];
							partes[partes.length - 1] = paginaTemp.replace(/\.asp/gi, "");
						} else {
							// es una página html, asp...
							// lo eliminamos
							partes.splice(partes.length - 1, 1);
						}
					}
				}
				
				if (partes.length == 0) {
					categoria = "portada";
				} else if (partes.length == 1) {
					if(this.cleanURL(partes[0])=="alava" || this.cleanURL(partes[0])=="almeria" || this.cleanURL(partes[0])=="jaen" || this.cleanURL(partes[0])=="albacete" || this.cleanURL(partes[0])=="alicante" || this.cleanURL(partes[0])=="jerez")
						categoria = "portada";
					else
						categoria = this.cleanURL(partes[0]);
				} else {
					// tenemos mas de 2 porciones de url, las cogemos como categoria y subcategoria
					categoria = this.cleanURL(partes[0]);
					if(/^\d{8}/.test(partes[1])){
						subcategoria = this.cleanURL(partes[2]);
					}
					else{
						subcategoria = this.cleanURL(partes[1]);
						if (this.cleanURL(partes[2]))
							subcategoria+= "/" +this.cleanURL(partes[2]);
					}
				}
			} else {
				var url = location.href;
				var partesURL = url.split("/");
				var pagina = partesURL[partesURL.length - 1];
				if (/\.(.)+$/.test(pagina)) {
					subcategoria = partesURL.splice(partesURL.length - 1, 1);
					categoria = partesURL.join("/");
				} else {
					categoria = url;
				}
			}
		} catch (e) {
		}
		
		return [categoria, subcategoria];
	},
	
	esDominioConocido: function() {
        var dominio = location.hostname;
        for (var portal in this.INFO_PORTALES) {
        	var servidores = this.INFO_PORTALES[portal].servidores;
        	for (var i = 0; i < servidores.length; i++) {
        		var candidato = servidores[i];
        		if (candidato == dominio) {
        			return true;
                }
           }
        }
         return false;
	},

	// zoneid:126,CAT_gente,SCATen-abctv,PORabctv,indios-vaqueros-alondra-bentley-54441
	/**
	 * Las zonas se cargaran de la configuracion, asi como el portal o site
	 */
	/*setValoresAdvernet: function(fo, opciones) {
		var result = [];
		
		var tags = null;
		if (opciones) {
			tags = opciones.tags || this.getKeyWords(opciones.titulo) || "";
		}
		if (tags) {
			tags = tags.replace(/[, ]/g, "-");
			result.push("tags::" + tags);
		}
		var categoria = undefined;
		var subcategoria = undefined;
		if (opciones) {
			categoria = opciones.categoriaPubli || undefined;
			subcategoria = opciones.subcategoriaPubli || undefined;
		}
		result.push("channel::" + categoria);
		result.push("subChannel::" + subcategoria);
		
		fo.addVariable("advernet", result.join(","));
	},*/
	
	_showVideo : function(id, video, w, h, opciones) {
		var funcion = this._showVideo;
		
		if (arguments.length < 5) {
			// Si no nos pasan un id de capa, creamos 1 en la posicion actual y la usamos para escribir el video
			// (CUIDADO!  Si la pagina ya esta cargada, siempre hay que indicar un id, sino borraria la pagina actual)
			var uid = this.getUID("video");
			document.write('<div id="' + uid + '"></div>');
			
			var args = new Array(5);
			args[0] = uid;
			for (var i = 0; i < arguments.length; i++) {
				args[i + 1] = arguments[i];
			}
			
			funcion.call(this, args[0], args[1], args[2], args[3], args[4]);
			return;
		}
		
		
		if (!opciones) {
			opciones = {};
		}
		
		// Esperamos que se cargue la imagen de mosca para poder calcular cual de las dos mostrar
		// si la pequeña o la normal o ninguna
		if (!this.init(opciones, video)) {
			var _this = this;
			setTimeout(function() {
				funcion.call(_this, id, video, w, h, opciones);
			}, 500);
			return;
		}
		
		// con esto conseguimos ids unicos
		var idPlayer = this.getUID("movie_player");
		var fo = new SWFObject(this.getURLBase("FLVPlayer.swf"), idPlayer, w, h, this.VERSION_FLASH, getColorFondo());
	
		// transparencia
		fo.addParam("wmode", "transparent");
		
		fo.addParam("swLiveConnect", "true");
		fo.addParam("allowScriptAccess", "always");
	
		// ruta del fichero de configuracion
		if (this.rutaConfig) {
			fo.addVariable("config", this.rutaConfig);
		}
		
		// URL del video
		if (video.indexOf('youtube.com') != -1) {
			var idYoutube = video.substring(video.indexOf('=')+1, video.length);
			fo.addVariable("file", idYoutube);
			fo.addVariable("cdn", "youtube");
		}
		else {
			fo.addVariable("file", video);
		}
		
		//comprueba si es live
		if ( (video.indexOf('rtmp://') != -1) || (video.indexOf('rtmpt://') != -1) ) {
			fo.addVariable("isLive", "true");
		}
		
		// alto y ancho
		fo.addVariable("width", parseInt(w, 10));
		fo.addVariable("height", parseInt(h, 10));
		
		// google analytics
		this.setValoresGoogleAnalytics(fo, opciones);
		
		// advernet
		//this.setValoresAdvernet(fo, opciones);
		
		//DART
		if (typeof (OAS_sitepage) != 'undefined'){
			fo.addVariable("advertisement","OAS_sitepage::" + getOAS_sitepage(OAS_sitepage));
		}else{
			fo.addVariable("advertisement","OAS_sitepage::");
		}
		
		if (opciones) {
			if (!opciones.titulo) {
				opciones.titulo = "Desconocido";
			}
			opciones.titulo = this.getCleanTitle(opciones.titulo);
			
			// pantalla completa
			if (opciones.fullscreen !== false) {
				fo.addParam("allowfullscreen", "true");
			}
			
			// imagen de previa
			if (opciones.imgPrevia) {
				//var imagen = this.getURLResizer(opciones.imgPrevia, w, h);
				if (opciones.usoResizer === false) {
					var imagen = opciones.imgPrevia;
				}
				else{
					var imagen = this.getURLResizer(opciones.imgPrevia, w, h);
				}
				imagen = imagen.replace(/&/g,"%26");
				fo.addVariable("image", imagen);
			}			
			if (opciones.autoplay) {
				fo.addVariable("autostart", "true");
			}
			
			// mosca
			var mosca = this.calculaMosca(w, h);
			if (mosca) {
				fo.addVariable("logo", "image::" + mosca);
			}
			
			// ajustar
			if (opciones.ajustar === true) {
				fo.addVariable("overstretch", "overstretch");
			} else if (opciones.ajustar === false) {
				fo.addVariable("overstretch", "maintain");
			} else if (opciones.ajustar) {
				fo.addVariable("overstretch", opciones.ajustar);
			} else {
				fo.addVariable("overstretch", "maintain");
			}
			
			// titulo del video
			if (opciones.titulo) {
				fo.addVariable("title", opciones.titulo);
			}
		} else {
			// Si no nos llega configuracion
			fo.addParam("allowfullscreen", "true");
			fo.addVariable("autostart", "false");
			fo.addVariable("overstretch", "maintain");
		}
	
		if (navigator && navigator.appName && navigator.appName == "Microsoft Internet Explorer") {
			setTimeout(function() {
				var contenedor = document.getElementById(id);
				if (contenedor) {
					contenedor.innerHTML = '<div style="text-align: center; margin:0 auto; position: relative"></div>';
					fo.write(contenedor.firstChild);
				}
				PlayerWebTV.ieCounter--;
			}, 500 * PlayerWebTV.ieCounter++);
		} else {
			var contenedor = document.getElementById(id);
			if (contenedor) {
				contenedor.innerHTML = '<div style="text-align: center; margin:0 auto; position: relative"></div>';
				fo.write(contenedor.firstChild);
			}
		}
	},
	
	_showAudio : function(id, video, w, h, opciones) {
		var funcion = this._showAudio;
		
		if (arguments.length < 5) {
			// Si no nos pasan un id de capa, creamos 1 en la posicion actual y la usamos para escribir el video
			// (CUIDADO!  Si la pagina ya esta cargada, siempre hay que indicar un id, sino borraria la pagina actual)
			var uid = this.getUID("video");
			document.write('<div id="' + uid + '"></div>');
			
			var args = new Array(5);
			args[0] = uid;
			for (var i = 0; i < arguments.length; i++) {
				args[i + 1] = arguments[i];
			}
			
			funcion.call(this, args[0], args[1], args[2], args[3], args[4]);
			return;
		}
		
		
		if (!opciones) {
			opciones = {};
		}
		
		// Esperamos que se cargue la imagen de mosca para poder calcular cual de las dos mostrar
		// si la pequeña o la normal o ninguna
		if (!this.init(opciones, video)) {
			var _this = this;
			setTimeout(function() {
				funcion.call(_this, id, video, w, h, opciones);
			}, 500);
			return;
		}
		
		// con esto conseguimos ids unicos
		var idPlayer = this.getUID("movie_player");
	
		var fo = new SWFObject(this.getURLBase("FLVPlayer.swf"), idPlayer, w, h,this.VERSION_FLASH, getColorFondo());
	
		// transparencia
		fo.addParam("wmode", "transparent");
		
		fo.addParam("swLiveConnect", "true");
		fo.addParam("allowScriptAccess", "always");
	
		// ruta del fichero de configuracion
		if (this.rutaConfig) {
			fo.addVariable("config", this.rutaConfig);
		}
		
		// URL del audio
		fo.addVariable("file", video);
		
		// alto y ancho
		fo.addVariable("width", parseInt(w, 10));
		fo.addVariable("height", parseInt(h, 10));
		
		// google analytics
		//this.setValoresGoogleAnalytics(fo, opciones);
		
		// advernet
		//this.setValoresAdvernet(fo, opciones);
		
		if (opciones) {
			if (!opciones.titulo) {
				opciones.titulo = "Desconocido";
			}
			opciones.titulo = this.getCleanTitle(opciones.titulo);
			
			// pantalla completa
			if (opciones.fullscreen !== false) {
				fo.addParam("allowfullscreen", "true");
			}
			
			// imagen de previa
			if (opciones.imgPrevia) {
				//fo.addVariable("image", this.getURLResizer(opciones.imgPrevia, w, h));
				if (w <= 253) var ancho =  253;
				else if (w > 253 && w <= 300) var ancho =  300;
				else if (w > 300 && w <= 384) var ancho =  384;
				else if (w > 384 && w <= 390) var ancho =  390;
				else if (w > 390 && w <= 665) var ancho =  665;
				//var imagen = this.getURLResizer(opciones.imgPrevia, w, h, 'audio-onda_' + ancho + '.png');
				if (opciones.usoResizer === false) {
					var imagen = opciones.imgPrevia;
				}
				else{
					var imagen = this.getURLResizer(opciones.imgPrevia, w, h, 'audio-onda_' + ancho + '.png');
				}
				imagen = imagen.replace(/&/g,"%26");
				fo.addVariable("image", imagen);
			}
			
			if (opciones.autoplay) {
				fo.addVariable("autostart", "true");
			}
			
			// mosca
			//var mosca = this.calculaMosca(w, h);
			//if (mosca) {
			//	fo.addVariable("logo", "image::" + mosca);
			//}
			
			// ajustar
			if (opciones.ajustar === true) {
				fo.addVariable("overstretch", "overstretch");
			} else if (opciones.ajustar === false) {
				fo.addVariable("overstretch", "maintain");
			} else if (opciones.ajustar) {
				fo.addVariable("overstretch", opciones.ajustar);
			} else {
				fo.addVariable("overstretch", "maintain");
			}
			
			// titulo del video
			if (opciones.titulo) {
				fo.addVariable("title", opciones.titulo);
			}
		} else {
			// Si no nos llega configuracion
			fo.addParam("allowfullscreen", "true");
			fo.addVariable("autostart", "false");
			fo.addVariable("overstretch", "maintain");
		}
	
		if (navigator && navigator.appName && navigator.appName == "Microsoft Internet Explorer") {
			setTimeout(function() {
				var contenedor = document.getElementById(id);
				if (contenedor) {
					contenedor.innerHTML = '<div style="text-align: center;"></div>';
					fo.write(contenedor.firstChild);
				}
				PlayerWebTV.ieCounter--;
			}, 500 * PlayerWebTV.ieCounter++);
		} else {
			var contenedor = document.getElementById(id);
			if (contenedor) {
				contenedor.innerHTML = '<div style="text-align: center;"></div>';
				fo.write(contenedor.firstChild);
			}
		}
	},	
	
	showVideo: function(id, video, w, h, opciones) {
		var extension = PlayerWebTV.getExtension(video);
		
		var funcion = this.showVideo;
		if (arguments.length < 5) {
			// Si no nos pasan un id de capa, creamos 1 en la posicion actual y la usamos para escribir el video
			// (CUIDADO!  Si la pagina ya esta cargada, siempre hay que indicar un id, sino borraria la pagina actual)
			var uid = this.getUID("video");
			document.write('<div id="' + uid + '"></div>');
			
			var args = new Array(5);
			args[0] = uid;
			for (var i = 0; i < arguments.length; i++) {
				args[i + 1] = arguments[i];
			}
			
			funcion.call(this, args[0], args[1], args[2], args[3], args[4]);
			return;
		}
		if (!opciones) {
			opciones = {};
		}
		
		var _this = this;
		if (!this.init(opciones, video)) {
			setTimeout(function() {
				funcion.call(_this, id, video, w, h, opciones);
			}, 500);
			return;
		}
		
		var contenedor = document.getElementById(id);
		
		if (contenedor) {
			if (opciones && opciones.imgPrevia) {
				if (extension == 'mp3') {
					var marcaAgua = 'audio-play.png';
				}
				else {
					var marcaAgua = 'play.png';
				}
				
				//var urlPreviaRedimensionada = this.getURLResizer(opciones.imgPrevia, w, h, marcaAgua);
				if (opciones.usoResizer === false) {
					var urlPreviaRedimensionada = opciones.imgPrevia;
				}
				else{
					var urlPreviaRedimensionada = this.getURLResizer(opciones.imgPrevia, w, h, marcaAgua);
				}
				
				this.pintarImagen(id, video, w, h, opciones, urlPreviaRedimensionada);
			} else {
				this.pintarImagen(id, video, w, h, opciones, null);
			}
		}
	},
	
	// Pinta los videos de BC para que se visualicen en una capa modal
	showVideoBC: function(div, video, w, h, opciones) {
		var funcion = this.showVideoBC;
		if(this.portal == null )this.portal = opciones.site;
		var idComentarios = div.substring(div.indexOf('-')+1, div.lastIndexOf('-'));
		var idPlayer = PlayerWebTV.INFO_PORTALES[opciones.site].idPlayer;
		if ((opciones.publicidadOn != undefined) && !opciones.publicidadOn) idPlayer = PlayerWebTV.INFO_PORTALES[opciones.site].idPlayerSinPublicidad;
		var idPublisher = PlayerWebTV.INFO_PORTALES[opciones.site].idPublisher;
		var bComentarios = false;
		var sVideoStillURL = "";
		var sIdVideo = "";
		var sPie = opciones.titulo;
		var sEntradilla = opciones.entradilla;
		var sEnlace = opciones.urlTitulo;
		var bVideoObtenido = (arguments.length > 5)?arguments[5]:false;
		var sComentarios = opciones.comentarios;
		var sApoyoTexto = opciones.apoyoTexto;
		var sApoyoURL = opciones.apoyoURL;
		var sAntetituloTexto = opciones.antetituloTexto;
		
		// Ancho y alto por defecto para la capa modal
		var iWidth=640;
		var iHeight=360;
		if ((opciones.capaModal != undefined) && (opciones.capaModal == false)) {
			// Si no abrimos en capa modal cogemos el alto y ancho definido por el usuario
			iWidth = w;
			iHeight = h;
			//alert (w+'x'+h);
			
		}else{//AÑADIDO POR JSJ PARA VERIFICAR SI LA CAPA MODAL SE ABRE CON INSKIN O NO
		
			//si es capa modal con inskin pondemos el tamaño adecuado y usamos el player con inskin
			if (inSkin){
				iWidth = 900;
				iHeight = 460;
				idPlayer = PlayerWebTV.INFO_PORTALES[opciones.site].idPlayerINSKIN				
				//alert ('capa modal!'); 
			}
			
		}
		
		var adTags = null;
		var sAutor = "";
		var sIdReference = "";
		var iIdModal = video +'-_-'+this.getUID("");
		// Si el video es de RC nos quedamos con la parte sin 'rc@'
		var iIdModalSinRC = ((iIdModal.toLowerCase().indexOf('rc@')!=-1)?iIdModal.substring(iIdModal.indexOf('@')+1):iIdModal);
		var sURLDataBC = '';
		if(isNaN(video)) {
			if(video.toLowerCase().indexOf('rc@') != -1) video = video.substring(video.indexOf('@')+1);
			//sURLDataBC = '/includes/manuales/webtv/phpproxy/phpproxy.php?medio='+ PlayerWebTV.INFO_PORTALES[opciones.site].medio +'&command=find_video_by_reference_id&video_fields=id,name,longDescription,linkURL,videoStillURL,tags,referenceId&custom_fields=origin&reference_id='+video;
			sURLDataBC = '/includes/manuales/webtv/phpproxy/phpproxy.php?medio='+ PlayerWebTV.INFO_PORTALES[opciones.site].medio +'&command=find_video_by_reference_id&video_fields=id,name,longDescription,linkURL,videoStillURL,tags,referenceId&custom_fields=autor&reference_id='+video;
		} else { // Si es video del propio portal lo buscamos por ID
			//sURLDataBC = '/includes/manuales/webtv/phpproxy/phpproxy.php?medio='+ PlayerWebTV.INFO_PORTALES[opciones.site].medio +'&command=find_video_by_id&video_fields=id,name,longDescription,linkURL,videoStillURL,tags,referenceId&custom_fields=origin&video_id='+video;
			sURLDataBC = '/includes/manuales/webtv/phpproxy/phpproxy.php?medio='+ PlayerWebTV.INFO_PORTALES[opciones.site].medio +'&command=find_video_by_id&video_fields=id,name,longDescription,linkURL,videoStillURL,tags,referenceId&custom_fields=autor&video_id='+video;
		}
		/*if(video.toLowerCase().indexOf('rc@') != -1) { // Si es video de RC buscamos por reference iD
			//sURLDataBC = '/includes/manuales/webtv/phpproxy/phpproxy.php?medio='+ PlayerWebTV.INFO_PORTALES[opciones.site].medio +'&command=find_video_by_reference_id&video_fields=id,name,longDescription,linkURL,videoStillURL,tags&custom_fields=origin&reference_id='+video.substring(video.indexOf('@')+1);
			sURLDataBC = '/includes/manuales/webtv/phpproxy/phpproxy.php?medio='+ PlayerWebTV.INFO_PORTALES[opciones.site].medio +'&command=find_video_by_reference_id&video_fields=id,name,longDescription,linkURL,videoStillURL,tags&custom_fields=autor&reference_id='+video.substring(video.indexOf('@')+1);
		} else { // Si es video del propio portal lo buscamos por ID
			//sURLDataBC = '/includes/manuales/webtv/phpproxy/phpproxy.php?medio='+ PlayerWebTV.INFO_PORTALES[opciones.site].medio +'&command=find_video_by_id&video_fields=id,name,longDescription,linkURL,videoStillURL,tags&custom_fields=origin&video_id='+video;
			sURLDataBC = '/includes/manuales/webtv/phpproxy/phpproxy.php?medio='+ PlayerWebTV.INFO_PORTALES[opciones.site].medio +'&command=find_video_by_id&video_fields=id,name,longDescription,linkURL,videoStillURL,tags&custom_fields=autor&video_id='+video;
		}*/
		if(getXMLHttpRequest()){
			$.ajax({
				url: sURLDataBC,
				dataType: 'json',
				data: null,
				async: false,
				success: function(data) {
					if (data != null ) {
						// Nos quedamos con el ID del por si lo que tenemos es el ID de referenci
						if (data.id!=null && sIdVideo=='') sIdVideo = data.id;  
						//...
						if (data.name!=null && sPie=='') sPie = data.name;
						if (data.longDescription!=null && sEntradilla=='')sEntradilla=data.longDescription;	  
						if (data.linkURL!=null && sEnlace=='') sEnlace = data.linkURL;
						if (data.videoStillURL!=null) sVideoStillURL = data.videoStillURL;
						if (data.tags!=null) adTags = data.tags;
						//if (data.customFields!=null) if(data.customFields.origin!=null)sAutor = data.customFields.origin;
						if (data.customFields!=null) if(data.customFields.autor!=null)sAutor = data.customFields.autor;
						if (data.referenceId!=null) sIdReference = data.referenceId;
						bVideoObtenido = true;
					}
				}
			});
		}
		
		/*
		 * Caso para noticias compartidas de la verdad a las provincias y viceversa
		 */
		if( !bVideoObtenido && ( this.portal == 'laverdad' || this.portal == 'lasprovincias' ) ) {
			var opcionesOpcional = {
				categoriaPubli: ((opciones.categoriaPubli==undefined)?'':opciones.categoriaPubli),
				titulo: ((opciones.titulo==undefined)?'':opciones.titulo),
				imgPrevia: ((opciones.imgPrevia==undefined)?'':opciones.imgPrevia),
				site: ((this.portal=='laverdad')?'lasprovincias':'laverdad'),
				entradilla: ((opciones.entradilla==undefined)?'':opciones.entradilla),
				urlTitulo: ((opciones.urlTitulo==undefined)?'':opciones.urlTitulo),
				imgPatrocinio: ((opciones.imgPatrocinio==undefined)?'':opciones.imgPatrocinio),
				urlPatrocinio: ((opciones.urlPatrocinio==undefined)?'':opciones.urlPatrocinio),
				clickcommand: ((opciones.clickcommand==undefined)?'':opciones.clickcommand),
				capaModal: ((opciones.capaModal == undefined)?true:opciones.capaModal),
				publicidadOn: ((opciones.publicidadOn == undefined)?true:opciones.publicidadOn),
				comentarios: ((opciones.comentarios == undefined) ? '' : opciones.comentarios),
				redesSociales: (opciones.redesSociales == undefined) ? true : opciones.redesSociales,
				apoyoTexto: ((opciones.apoyoTexto==undefined)?'':opciones.apoyoTexto),
				apoyoURL: ((opciones.apoyoURL==undefined)?'':opciones.apoyoURL),
				antetituloTexto: ((opciones.antetituloTexto==undefined)?'':opciones.antetituloTexto)
			};
			(this.portal=='laverdad')?this.portal='lasprovincias':this.portal='laverdad';
			funcion.call(this, arguments[0], arguments[1], arguments[2], arguments[3], opcionesOpcional, true);
			return;
		}
		/*
		 * FIN CASO LAVERDAD Y LASPROVINCIAS
		 */
			
		

		
		//if(opciones.imgPrevia == "" && isVideoBC(video)) opciones.imgPrevia = sVideoStillURL;
		if(opciones.imgPrevia == "") opciones.imgPrevia = sVideoStillURL;
		var contenedor = document.getElementById(div);

		if (contenedor) {
			if (opciones && opciones.imgPrevia) {
				var marcaAgua = 'bt-video.gif';
				
				// Comprobamos si es imagen haciendo uso extendido de resizer con video_id o video_refid
				if ((opciones.imgPrevia.indexOf("resizer.php") != -1) && (opciones.imgPrevia.indexOf("video_") != -1)) {
					var urlPreviaRedimensionada = opciones.imgPrevia;
				}
				// En caso contrario el modo de funcionamiento es el normal
				else {
					if(opciones.imgPrevia.indexOf("resizer.php")!= -1){
						opciones.imgPrevia = opciones.imgPrevia.substring(opciones.imgPrevia.indexOf('imagen=')+7, opciones.imgPrevia.indexOf('.jpg')+4);
					} 
					//var urlPreviaRedimensionada = this.getURLResizer(opciones.imgPrevia, w, h, marcaAgua);
					if (opciones.usoResizer === false) {
						var urlPreviaRedimensionada = opciones.imgPrevia;
					}
					else{
						var urlPreviaRedimensionada = this.getURLResizer(opciones.imgPrevia, w, h, marcaAgua);
					}
				}
				
				this.pintarImagen(div, iIdModal, w, h, opciones, urlPreviaRedimensionada);
			} else {
				this.pintarImagen(div, iIdModal, w, h, opciones, null);
			}
			var divVars = document.createElement('div');
			divVars.setAttribute('id', 'photo-'+iIdModalSinRC+'-modal-2');
			var divCod = document.createElement('div');
			divCod.setAttribute('class', 'player-modal');
			divCod.setAttribute('id', 'photo-'+iIdModalSinRC+'-modal');
			contenedor.parentNode.appendChild(divVars);
			contenedor.parentNode.appendChild(divCod);
		}
		$('#photo-'+iIdModalSinRC+'-modal-2').attr('style', 'display: none');
		$('#photo-'+iIdModalSinRC+'-modal').attr('style', 'display: none');
				
		//Vemos si el tag del video tiene algún patrocinio asociado
		if(opciones.imgPatrocinio=='' || opciones.urlPatrocinio=='') {
			var hayPatrocinio = false;
			var numTags = (adTags != null)?adTags.length:0;
			for(var i=0;!hayPatrocinio && i < numTags; i++) {
				if(getDatosTagPatrocinado(opciones.site, adTags[i]) != null){
					opciones.imgPatrocinio = getDatosTagPatrocinado(opciones.site, adTags[i]).imgPatrocinio;
					opciones.urlPatrocinio = getDatosTagPatrocinado(opciones.site, adTags[i]).urlPatrocinio;
					opciones.clickcommand = '';//getDatosTagPatrocinado(opciones.site, adTags[i]).clickcommand;
					hayPatrocinio = true;
				}
			}
		}
		
		//Obtenemos el código del video
		sPie = sPie.replace(/"/g, "'");
		sPie = sPie.replace(/'/g, "\'");
		sEntradilla = sEntradilla.replace(/"/g, "'");
		sEntradilla = sEntradilla.replace(/'/g, "\'");
		var vars = "idVideo="+sIdVideo+"#;#w="+iWidth+"#;#h="+iHeight+"#;#idPlayer="+idPlayer+"#;#url="+sEnlace+"#;#pie="+sPie+"#;#entradilla="+sEntradilla+"#;#comentarios="+idComentarios+"#;#idDiv="+iIdModalSinRC+"#;#imgPatrocinio="+opciones.imgPatrocinio+"#;#urlPatrocinio="+opciones.urlPatrocinio+"#;#clickcommand="+opciones.clickcommand+"#;#site="+opciones.site+"#;#rSociales="+opciones.redesSociales+"#;#autor="+sAutor+"#;#apoyoTexto="+sApoyoTexto+"#;#apoyoURL="+sApoyoURL+"#;#antetituloTexto="+sAntetituloTexto+"#;#comment="+sComentarios+"#;#idRefencia="+sIdReference;
		
		var variables = document.createTextNode(vars);
		document.getElementById("photo-"+iIdModalSinRC+"-modal-2").appendChild(variables);
	},
	
	pintarImagen: function(id, video, w, h, opciones, urlImgPrevia, imgPrevia) {
		var videoBC = '';
		if(video.indexOf('-_-') != -1) {
			videoBC = video.split('-_-');
		}
		var extension = 'mp4';
		//if(videoBC=='' || !isVideoBC(videoBC[0])) {
		if(videoBC=='') {
			extension = PlayerWebTV.getExtension(video);
		}
		
		var _this = this;
		var funcion = this.pintarImagen;
		
		if (urlImgPrevia && !imgPrevia) {
			var imgPrevia = new Image();
			imgPrevia.src = urlImgPrevia;
			if (imgPrevia.complete) {
				funcion.call(_this, id, video, w, h, opciones, urlImgPrevia, imgPrevia);
			} else {
				imgPrevia.onload = function() {
					funcion.call(_this, id, video, w, h, opciones, urlImgPrevia, imgPrevia);
				};
				imgPrevia.onerror = imgPrevia.onabort = function() {
					funcion.call(_this, id, video, w, h, opciones, urlImgPrevia, new Image());
				};
			}
		} else if (!urlImgPrevia || (urlImgPrevia && imgPrevia)) {
			if (!urlImgPrevia) {
				imgPrevia = new Image();
			}
			
			var contenedor = document.getElementById(id);
			var alto = parseInt(h, 10);
			var ancho = parseInt(w, 10);
			var tamIcono = [64, 61];
			
			opciones.autoplay = true;
			
			var accion = function() {
				if (extension == 'mp3') {
					_this._showAudio(id, video, w, h, opciones);
					this.onclick = _this.nada;
				}
				else {
					_this._showVideo(id, video, w, h, opciones);
					this.onclick = _this.nada;
				}
			};
			
			var estrategia = "MarcaAguaEncajar";
			switch (estrategia) {
				case "SinMarcaAguaPosicionado":
					// Version con play posicionado (problemas con IE6)
					this.getHTMLImagenPosicion(ancho, alto, tamIcono, imgPrevia, contenedor, accion, extension);
				break;
				case "MarcaAguaAncho100AltoProporcional":
					// Version con ancho 100% y alto proporcional
					this.getHTMLImagenMarcaAguaAltoProporcional(ancho, alto, tamIcono, imgPrevia, contenedor, accion, extension);
				break;
				case "MarcaAguaEncajar":
				default:
					// Version con marca de agua e imagen centrada horizontal y verticalmente
					//if(isVideoBC(videoBC[0])) {
						//this.getHTMLImagenMarcaAguaBC(PlayerWebTV.INFO_PORTALES[opciones.site].resizer,PlayerWebTV.INFO_PORTALES[opciones.site].medio,ancho, alto, tamIcono, imgPrevia, id, video, opciones.capaModal);
					//} else {
						//this.getHTMLImagenMarcaAgua(ancho, alto, tamIcono, imgPrevia, contenedor, accion, extension);
					//}
					if ((video.indexOf('http://cache1.agilecontents.com')!= -1) || (extension == 'mp3')) {
						this.getHTMLImagenMarcaAgua(ancho, alto, tamIcono, imgPrevia, contenedor, accion, extension);
					} else {
						this.getHTMLImagenMarcaAguaBC(PlayerWebTV.INFO_PORTALES[opciones.site].resizer,PlayerWebTV.INFO_PORTALES[opciones.site].medio,ancho, alto, tamIcono, imgPrevia, id, video, opciones.capaModal, opciones.titulo);

					}
				break;
			}
		}
	},
	
	// Version con play posicionado (problemas con IE6)
	getHTMLImagenPosicion: function(ancho, alto, tamIcono, imgPrevia, contenedor, accion, extension) {
		if (extension == 'mp3') {
			var textoAlt = 'Pulse para escuchar el audio';
			var imagenPlay = 'imagenes/audio-play.png';
		}
		else {
			var textoAlt = 'Pulse para ver el video';
			var imagenPlay = 'imagenes/play.png';
		}
		
		var styleIcono = "margin-left: " + (ancho/2 - tamIcono[0]/2) + "px; top: " + (alto/2 - tamIcono[1]/2) + "px;";
		var html = '<div style="text-align: center; margin:0 auto; position: relative;"><div style="position: relative; margin:0 auto;cursor: pointer; background-color: ' + getColorFondo() + '; width: ' + ancho + 'px; height: ' + alto + 'px; position: relative; z-index:0;">';
		html += '<img src="' + this.getURLBase(imagenPlay) + '" alt="' + textoAlt + '" title="' + textoAlt + '" style="margin:0 auto; text-align:center; border: 0; position: absolute; z-index: 101; ' + styleIcono + '" />';
		if (imgPrevia && (imgPrevia.width + imgPrevia.height) > 0) {
			var style = "";
			var proporcionPlayer = ancho / alto;
			var proporcionImagen = imgPrevia.width / imgPrevia.height;
			
			var altoFinal = imgPrevia.height;
			var anchoFinal = imgPrevia.width;
			
			if (proporcionPlayer > proporcionImagen) {
				anchoFinal = anchoFinal * alto / altoFinal;
				altoFinal = alto;
			} else {
				altoFinal = altoFinal * ancho / anchoFinal;
				anchoFinal = ancho;
			}
			// centramos la imagen
			var coords = [(ancho - anchoFinal) / 2, (alto - altoFinal) / 2];
			var style = "height: " + altoFinal + "px; width: " + anchoFinal + "px; position: absolute; z-index: 100; top: " + coords[1] + "px; left: " + coords[0] + "px;";
			
			html += '<img src="' + imgPrevia.src + '" alt="' + textoAlt + '" title="' + textoAlt + '" style="border: 0; margin:0 auto; text-align:center;' + style + '" />';
		} else {
			html += '<img src="' + this.getURLBase(imagenPlay) + '" alt="' + textoAlt + '" title="' + textoAlt + '" style="margin:0 auto; text-align:center; border: 0; margin-top: ' + ((alto - tamIcono[1]) / 2) + 'px;" />';
		}
		if (extension == 'mp3') {
			html += '<div class="link-app2a"><div class="related-link"><a><img src="/img/bt-audio.gif">AUDIO</a><span class="rltrans"></span></div></div></div></div>';
		}else{
			html += '<div class="link-app2a"><div class="related-link"><a><img src="/img/bt-video.gif">V&Iacute;DEO</a><span class="rltrans"></span></div></div></div></div>';
		}
		
		contenedor.innerHTML = html;
		contenedor.firstChild.firstChild.onclick = accion;
	},
	
	// Version con marca de agua e imagen centrada horizontal y verticalmente
	getHTMLImagenMarcaAgua: function(ancho, alto, tamIcono, imgPrevia, contenedor, accion, extension) {

		if (extension == 'mp3') {
			var textoAlt = 'Pulse para escuchar el audio';
			var imagenPlay = 'imagenes/audio-play.png';
		}
		else {
			var textoAlt = 'Pulse para ver el video';
			var imagenPlay = 'imagenes/play.png';
		}
		// creamos el DOM
		var divExterno = "externo_"+PlayerWebTV.getUID("");
		var divInterno = "interno_"+PlayerWebTV.getUID("");
		var divext = document.createElement("div");
		divext.setAttribute("id", divExterno);
		//divext.setAttribute("style", "text-align: center; margin:0 auto; position: relative;");
		var divint = document.createElement("div");
		divint.setAttribute("id", divInterno);
		//divint.setAttribute("style", "margin:0 auto;cursor: pointer; background-color:" + getColorFondo() + "; width: " + ancho + "px; height: " + alto + "px; position: relative; z-index:0;");
		divext.appendChild(divint);
		var html = '<div style="text-align: center; margin:0 auto; position: relative;"><div style="margin:0 auto;cursor: pointer; background-color: ' + getColorFondo() + '; width: ' + ancho + 'px; height: ' + alto + 'px; position: relative; z-index:0;">';
		if (imgPrevia && (imgPrevia.width + imgPrevia.height) > 0) {
			var style = "";
			var proporcionPlayer = ancho / alto;
			var proporcionImagen = imgPrevia.width / imgPrevia.height;
			
			var altoFinal = imgPrevia.height;
			var anchoFinal = imgPrevia.width;
			
			if (proporcionPlayer > proporcionImagen) {
				anchoFinal = anchoFinal * alto / altoFinal;
				altoFinal = alto;
			} else {
				altoFinal = altoFinal * ancho / anchoFinal;
				anchoFinal = ancho;
			}
			// centramos la imagen
			var coords = [(ancho - anchoFinal) / 2, (alto - altoFinal) / 2];
			var style = "height: " + altoFinal + "px; width: " + anchoFinal + "px; margin-top: " + coords[1] + "px;";
			var img = document.createElement("img");
			img.setAttribute("src", imgPrevia.src);
			img.setAttribute("alt", textoAlt);
			img.setAttribute("title", textoAlt);
			var uidImagen = this.getUID("imagenVisor");
			img.setAttribute("id", uidImagen);
			divint.appendChild(img);
			var capaVideo = divint.innerHTML;
			capaVideo += "<div class='link-app2a'><div class='related-link'><a><img src='/img/bt-audio.gif'>AUDIO</a><span class='rltrans'></span></div></div></div></div>";
			divint.innerHTML = capaVideo;
			contenedor.appendChild(divext);
			$("#"+divExterno).attr('style', 'text-align: center; margin:0 auto; position: relative;');
			$("#"+divExterno).removeAttr('id');
			$("#"+divInterno).attr('style', 'margin:0 auto;cursor: pointer; background-color:' + getColorFondo() + '; width: ' + ancho + 'px; height: ' + alto + 'px; position: relative; z-index:0;');
			$("#"+divInterno).removeAttr('id');
			
			var first = contenedor.children[0].children[0];
			if(first){
				contenedor.children[0].children[0].onclick = accion;
			}else
			{
				contenedor.children[0].onclick = accion;
			}
		
		} else {
			var img = document.createElement("img");
			img.setAttribute("src", this.getURLBase(imagenPlay));
			img.setAttribute("alt", textoAlt);
			img.setAttribute("title", textoAlt);
			img.setAttribute("style", "margin:0 auto; text-align:center; border: 0; margin-top:"+((alto - tamIcono[1]) / 2)+"px;");
			divint.appendChild(img);
			document.getElementById(contenedor).appendChild(divext);
		}
		
	},
	
	// Version con marca de agua e imagen centrada horizontal y verticalmente
	
	getHTMLImagenMarcaAguaBC: function(site, medio, ancho, alto, tamIcono, imgPrevia, div, video, capaModal, titulo) {
		//var textoAlt = 'Pulse para ver el video';
		var textoAlt = titulo.replace(/&quot;/g, "'");
		var imagenPlay = 'imagenes/play.png';
		var jsPlay = '';		
		// Nos quedamos con la parte buena del video sin 'rc@'
		var videoSinRC = ((video.toLowerCase().indexOf('rc@')!=-1)?video.substring(video.indexOf('@')+1):video);

		// Calculamos el ID del enlace para la capa modal
		var idEnlaceCapaModal = 'enlaceCapaModal_' + videoSinRC;
		
		if (DetectAndroid()) {
			var dominio = site;
			try {
				var dominioURL = document.domain;
				if (dominioURL.indexOf('.') != -1) dominioURL = dominioURL.split('.')[1];
				dominio = PlayerWebTV.INFO_PORTALES[dominioURL].dominio;
				if (dominio.indexOf('http://') != -1) dominio = dominio.substring ('http://'.length, dominio.length);
			} catch (err) {
				dominio = site;
			}
			jsPlay = obtieneRutaMP4Video (dominio, medio, video, idEnlaceCapaModal);
		}
		else if (capaModal) {
			jsPlay = 'javascript:openModal("'+site+'","'+medio+'","'+videoSinRC+'")';
		}
		else {
			jsPlay = 'javascript:openVideoDiferido("'+site+'","'+medio+'","'+videoSinRC+'", "'+div+'")';
		}		
		
		//Modificado por Diego ;-)
		//Abrimos el modal en el enlace de noticia
		//alert(jsPlay);
		$('.enlace_' + div).attr('href', jsPlay);
		
		// creamos el DOM
		var divExterno = "externo_"+PlayerWebTV.getUID("");
		var divInterno = "interno_"+PlayerWebTV.getUID("");
		var divext = document.createElement("div");
		divext.setAttribute("id", divExterno);
		//divext.setAttribute("style", "text-align: center; margin:0 auto; position: relative;");
		var divint = document.createElement("div");
		divint.setAttribute("id", divInterno);
		//divint.setAttribute("style", "margin:0 auto;cursor: pointer; background-color:" + getColorFondo() + "; width: " + ancho + "px; height: " + alto + "px; position: relative; z-index:0;");
		divext.appendChild(divint);
		if (imgPrevia && (imgPrevia.width + imgPrevia.height) > 0) {
			var style = "";
			var proporcionPlayer = ancho / alto;
			var proporcionImagen = imgPrevia.width / imgPrevia.height;
			var altoFinal = imgPrevia.height;
			var anchoFinal = imgPrevia.width;
			if (proporcionPlayer > proporcionImagen) {
				anchoFinal = anchoFinal * alto / altoFinal;
				altoFinal = alto;
			} else {
				altoFinal = altoFinal * ancho / anchoFinal;
				anchoFinal = ancho;
			}
			// centramos la imagen
			var coords = [(ancho - anchoFinal) / 2, (alto - altoFinal) / 2];
			var style = "height: " + altoFinal + "px; width: " + anchoFinal + "px; margin-top: " + coords[1] + "px;";
			// continuamos creando el DOM
			var link = document.createElement("a");
			link.setAttribute("href", jsPlay);
			divint.appendChild(link);
			var img = document.createElement("img");
			img.setAttribute("src", imgPrevia.src);
			img.setAttribute("alt", textoAlt);
			img.setAttribute("title", textoAlt);
			var uidImagen = this.getUID("imagenVisor");
			img.setAttribute("id", uidImagen);
			link.appendChild(img);
			if(ancho>84&&alto>84)	{
				var capaVideo = divint.innerHTML;
				capaVideo += "<div class='link-app2a'><div class='related-link'><a href='"+jsPlay+"' id='" + idEnlaceCapaModal + "'><img src='http://www."+site+"/img/bt-video.gif'>V&Iacute;DEO</a><span class='rltrans'></span></div></div></div></div>";
				divint.innerHTML = capaVideo;
			}
			document.getElementById(div).appendChild(divext);
			if(alto > altoFinal){
				$("#" + uidImagen).attr('style', 'width:' + anchoFinal +'px;height:' + altoFinal +'px;margin:0 auto; text-align:center; border: 0;margin-top: ' + coords[1] + 'px;');
			} else {
				$("#" + uidImagen).attr('style', 'width:' + anchoFinal +'px;height:' + altoFinal +'px;margin:0 auto; text-align:center; border: 0;');
			}
			$("#"+divExterno).attr('style', 'text-align: center; margin:0 auto; position: relative;');
			$("#"+divExterno).removeAttr('id');
			$("#"+divInterno).attr('style', 'margin:0 auto;cursor: pointer; background-color:' + getColorFondo() + '; width: ' + ancho + 'px; height: ' + alto + 'px; position: relative; z-index:0;');
			$("#"+divInterno).removeAttr('id');
		} else {
			var link = document.createElement("a");
			link.setAttribute("href", jsPlay);
			divint.appendChild(link);
			var img = document.createElement("img");
			img.setAttribute("src", this.getURLBase(imagenPlay));
			img.setAttribute("alt", textoAlt);
			img.setAttribute("title", textoAlt);
			img.setAttribute("style", "margin:0 auto; text-align:center; border: 0; margin-top:"+((alto - tamIcono[1]) / 2)+"px;");
			link.appendChild(img);
			document.getElementById(div).appendChild(divext);
		}
		if(ancho<85||alto<85)	{
				var divImg = "img_"+PlayerWebTV.getUID("");
				var styleplay = document.createElement("div");
				styleplay.setAttribute("id", divImg);
				var aplay = document.createElement("a");
				aplay.setAttribute("href", jsPlay);
				var imgplay = document.createElement("img");
				imgplay.setAttribute("src", "/img/bt-video.gif");
				aplay.appendChild(imgplay);
				styleplay.appendChild(aplay);
				divint.appendChild(styleplay);
				$("#"+divImg).attr('style', 'right: 2pt; position: absolute; bottom:2pt; width:30px;');
				$("#"+divImg).removeAttr('id');
			}
	},
	
	// Version con ancho 100% y alto proporcional
	getHTMLImagenMarcaAguaAltoProporcional: function(ancho, alto, tamIcono, imgPrevia, contenedor, accion, extension) {
		if (extension == 'mp3') {
			var textoAlt = 'Pulse para escuchar el audio';
			var imagenPlay = 'imagenes/audio-play.png';
		}
		else {
			var textoAlt = 'Pulse para ver el video';
			var imagenPlay = 'imagenes/play.png';
		}
		
		// Version con marca de agua e imagen ocupa todo el ancho y alto proporcional
		var html = '<div style="text-align: center; margin:0 auto; position: relative"><div style="margin:0 auto; background-color: ' + getColorFondo() + '; cursor: pointer; width: ' + ancho + 'px;">';
		if (imgPrevia && (imgPrevia.width + imgPrevia.height) > 0) {
			html += '<img src="' + imgPrevia.src + '" alt="' + textoAlt + '" title="' + textoAlt + '" style="margin:0 auto; text-align:center; border: 0 " />';
		} else {
			html += '<img src="' + this.getURLBase(imagenPlay) + '" alt="' + textoAlt + '" title="' + textoAlt + '" style="margin:0 auto; text-align:center; border: 0; margin-top: ' + ((alto - tamIcono[1]) / 2) + 'px;" />';
		}
		html += '</div></div>';
		
		contenedor.innerHTML = html;
		contenedor.firstChild.firstChild.onclick = accion;
	},
	
	/**
	 * Obtiene la URL completa para un recurso, según el portal especificado
	 */
	getURLBase: function(url) {
		if (this.portal && this.INFO_PORTALES[this.portal]) {
			if (this.INFO_PORTALES[this.portal].baseConfig) {
				// si el portal tiene un baseConfig especifico, lo uso
				return this.INFO_PORTALES[this.portal].dominio + this.INFO_PORTALES[this.portal].baseConfig + url;
			} else {
				return this.INFO_PORTALES[this.portal].dominio + this.BASE_CONFIG + url;
			}
		} else {
			return this.BASE_CONFIG + url;
		}
	},
	
	/**
	 * Combierte URL's relativas al servidor en URL's absolutas.  Utilizado para el resizer
	 */
	getFullURL: function(src) {
		if (src.indexOf("//") == -1 && !(src.charAt(0) == "/")) {
			// la ruta es relativa a la pagina
			// src = "nivel2/imagen.png"
			var ruta = location.href.substring(0, location.href.lastIndexOf("/") + 1);
			src = ruta + src;
		} else if (src.charAt(0) == "/") {
			// la ruta de la imagen es relativa al servidor, concatenamos el servidor actual
			// src = "/carpeta/imagen.png"
			src = location.protocol + "//" + location.host + src;
		}
		return src;
	},
	
	/**
	 * Devuelve la URL para pedir al resizer la nueva imagen
	 */
	getURLResizer: function(src, ancho, alto, marcaAgua) {
		var result = this.getFullURL(src);
		
		if (this.portal) {
			var medio = "";
			var medio = this.INFO_PORTALES[this.portal].resizer;
			
			if (!medio) {
				medio = this.portal + ".es";
			}
			
			if (!isDesarrolloABC()) {
				if (marcaAgua) {
					result = "http://resizer." + medio + "/resizer/resizer.php?imagen=" + result + "&nuevoancho=" + ancho + "&nuevoalto=" + alto + "&copyright=false&encrypt=false&posmarca=C&transparencia=85";
				}  else {
					result = "http://resizer." + medio + "/resizer/resizer.php?imagen=" + result + "&nuevoancho=" + ancho + "&nuevoalto=" + alto + "&copyright=conCopyright&encrypt=false";
				}
			}
		}
		
		return result;
	}
};

/**
 * Incluimos las propiedades estaticas en el prototipo
 */
(function() {
	var prototipo = PlayerWebTV.prototype;
	for (var prop in PlayerWebTV) {
		if (prop != "prototype") {
			prototipo[prop] = PlayerWebTV[prop];
		}
	}
})();

/**
* Funciones para la capa modal del video de directo
*/
function openModal(site,medio,id, video) {

	//añadido por jsj si es capa modal con inskin pondemos el tamaño adecuado y usamos el player con inskin
	var simpleModalJS = '';
	
	if (inSkin){
		simpleModalJS = '/js/ctv/jquery.simplemodal.inskin.js';
	}else{
		simpleModalJS = '/js/jquery.simplemodal.js';	
	}
	
	
	var idComent = "";
	if(arguments.length == 2){ // Si es video en directo
		video = medio;
		id = site;
		var obj = cambiaAutoStart(video);
		obj = cambiaAltoAncho(obj);
		$("#capaVideo_"+id).html(unescape(obj));
		getIdWMPlayer(obj);
	}else { // Si es un video de BC normal o de performgroup
		if(id == 'performgroup'){
			var performTemp = video.split('##');
			var performplayer = performTemp[0];
			var performid = performTemp[1];
			video = getPerformPlayerObj(performplayer, performid);
			id = site;
			var obj = cambiaAutoStart(video);
			obj = cambiaAltoAncho(obj);
			$("#capaVideo_"+id).html(unescape(obj));
			getIdWMPlayer(obj);
		}else{
			var txt = $("#photo-"+id+"-modal-2").text();
			var variables = txt.split('#;#');
			var obj = getVideoObject(site,
									 medio,
								     variables[0].substring(variables[0].indexOf('=')+1),
									 variables[1].substring(variables[1].indexOf('=')+1),
									 variables[2].substring(variables[2].indexOf('=')+1),
									 variables[3].substring(variables[3].indexOf('=')+1),
									 variables[4].substring(variables[4].indexOf('=')+1),
									 variables[5].substring(variables[5].indexOf('=')+1),
									 variables[6].substring(variables[6].indexOf('=')+1),
									 variables[7].substring(variables[7].indexOf('=')+1),
									 variables[8].substring(variables[8].indexOf('=')+1),
									 variables[9].substring(variables[9].indexOf('=')+1),
									 variables[10].substring(variables[10].indexOf('=')+1),
									 variables[11].substring(variables[11].indexOf('=')+1),
									 variables[13].substring(variables[13].indexOf('=')+1),
									 variables[14].substring(variables[14].indexOf('=')+1),
									 variables[15].substring(variables[15].indexOf('=')+1),
									 variables[16].substring(variables[16].indexOf('=')+1),
	 								 variables[17].substring(variables[17].indexOf('=')+1),
									 variables[18].substring(variables[18].indexOf('=')+1),
									 variables[19].substring(variables[19].indexOf('=')+1));
			var site = variables[12].substring(variables[12].indexOf('=')+1);
			if( site = 'laverdad' || site == 'lasprovincias' ) { // Caso que las provincias publique para la verdad y viceversa
				var dominio = PlayerWebTV.INFO_PORTALES[site].dominio;
				simpleModalJS = ((dominio.indexOf(site) != -1 )?PlayerWebTV.INFO_PORTALES[site].dominio:PlayerWebTV.INFO_PORTALES[site].dominio2)+simpleModalJS;
			} else {
				simpleModalJS = ((site!='')?PlayerWebTV.INFO_PORTALES[site].dominio:'')+simpleModalJS;
			}
			
			$("#photo-"+id+"-modal").html(obj);
			idComent = variables[7].substring(variables[7].indexOf('=')+1);
		}
	}

	$("object").attr("z-index", "-1");
	$("embed").attr("wmode", "transparent");
	$("param[name|=wmode]").attr("value", "transparent");
	$("#photo-" + id + "-modal object embed").attr("wmode", "opaque");
	$("#photo-" + id + "-modal object").attr("z-index", "10000");
	$.getScript(simpleModalJS, function() {
		$("#photo-" + id + "-modal").modal();
		if ( idComent != "" && idComent.length > 1 ) getNumComentariosPortada("'"+idComent+"'");
		errorVerdadProvincias = false;
	});
	
	$("#photo-"+id+"-modal").removeClass();
	$("#photo-"+id+"-modal").addClass('player-modal');
}

function getPerformPlayerObj(performplayer, performid) {
	//var performplayer = '<xsl:value-of select="str:getElementFromSplittedText(string(/doc/lead/link-app2/related-link[position()=1]/a/@href),string('::'),string('1'))"/>';
	//var performid = '<xsl:value-of select="str:getElementFromSplittedText(string(/doc/lead/link-app2/related-link[position()=1]/a/@href),string('::'),string('2'))"/>';
	/*
	var codePerform = '\u003Cobject id="kgt7hpyqukmv1i6p6or3ywpnc" width="640" height="360" type="application/x-shockwave-flash" name="kgt7hpyqukmv1i6p6or3ywpnc" data="http://static.eplayer.performgroup.com/ptvFlash/eplayer2/Eplayer.swf"\u003E';
	codePerform += '<param name="scale" value="noscale"/>';
	codePerform += '<param name="wmode" value="transparent"/>';
	codePerform += '<param name="base" value="http://static.eplayer.performgroup.com/ptvFlash/eplayer2/data/"/>';
	codePerform += '<param name="bgcolor" value="#000000"/>';
	codePerform += '<param name="allowfullscreen" value="true"/>';
	codePerform += '<param name="allowscriptaccess" value="always"/>';
	codePerform += '<param name="alignment" value="TL"/>';
	codePerform += '<param name="flashvars" value="channelId='+performplayer+'&amp;videoUUId='+performid+'&amp;partnerId=&amp;autoPlay=true&amp;startMute=null&amp;playerId=kgt7hpyqukmv1i6p6or3ywpnc&amp;playerType=eplayer15&amp;configXML=http://xml.eplayer.performgroup.com/eplayer/config/kgt7hpyqukmv1i6p6or3ywpnc&amp;SWFWidth=640&amp;SWFHeight=360"/>';
	codePerform += '\u003C/object\u003E';
	return codePerform;
	*/
	var codePerform = '';
	//codePerform += '<div id="perfkgt7hpyqukmv1i6p6or3ywpnc-' + performid + '">';
	//codePerform += '<script type="text/javascript" src="http://static.eplayer.performgroup.com/flash/js/swfobject.js"></script>';
	//codePerform += '<script type="text/javascript" src="http://static.eplayer.performgroup.com/flash/js/performgroup.js"></script>';
	//codePerform += '<script>addCustomPlayer("kgt7hpyqukmv1i6p6or3ywpnc", "' + performplayer + '", "' +  performid + '", "640", "360", "perfkgt7hpyqukmv1i6p6or3ywpnc-' + performid + '", "eplayer24");</script>';
	//codePerform += '</div>';
	
	codePerform += '<div id="perfkgt7hpyqukmv1i6p6or3ywpnc-' + performid + '">';
	codePerform += '</div>';
	var swfobject = 'http://static.eplayer.performgroup.com/flash/js/swfobject.js'; 
	var performgroup = 'http://static.eplayer.performgroup.com/flash/js/performgroup.js'; 
	$.getScript(swfobject, function() {
		$.getScript(performgroup, function() {
			addCustomPlayer("kgt7hpyqukmv1i6p6or3ywpnc", performplayer, performid , "640", "360", "perfkgt7hpyqukmv1i6p6or3ywpnc-" + performid, "eplayer20");
		});
	});

	return codePerform;
}

function openVideoDiferido(site, medio,id, div) {
	var txt = $("#photo-"+id+"-modal-2").text();
	var variables = txt.split('#;#');
	//alert ('NO MODAL');

	var obj = getEmbedVideo(site,medio,div, variables[0].substring(variables[0].indexOf('=')+1),
							 variables[1].substring(variables[1].indexOf('=')+1),
							 variables[2].substring(variables[2].indexOf('=')+1),
							 variables[3].substring(variables[3].indexOf('=')+1),
							 variables[19].substring(variables[19].indexOf('=')+1));

	$("#"+div+"").html(obj);
}

function cambiaAutoStart(txt) {
	if( txt.toLowerCase().indexOf('microsoft') != -1 ) {
		if(txt.toLowerCase().indexOf('value="true" name="autostart"') != -1)
			txt = txt.toLowerCase().replace('value="true" name="autostart"', 'value="false" name="autostart"');
		if(txt.toLowerCase().indexOf('name="autostart" value="true"') != -1)
			txt = txt.toLowerCase().replace('name="autostart" value="true"', 'name="autostart" value="false"');
		if(txt.toLowerCase().indexOf('name="autostart" value="1"') != -1) 
			txt = txt.toLowerCase().replace('name="autostart" value="1"', 'name="autostart" value="0"');
		if(txt.toLowerCase().indexOf('value="1" name="autostart"') != -1) 
			txt = txt.toLowerCase().replace('value="1" name="autostart"', 'value="0" name="autostart"');
		if(txt.toLowerCase().indexOf('autostart="true"') != -1) 
			txt = txt.toLowerCase().replace('autostart="true"', 'autostart="false"');
		if(txt.toLowerCase().indexOf('autostart="0"') != -1) 
			txt = txt.toLowerCase().replace('autostart="0"', 'autostart="1"');
	}
	return txt;
}

function cambiaAltoAncho(txt) {
	
	var width='';
	var height='';
	
	//añadido por jsj, si hay skin y es modal la capa...
	if (inSkin){
		width='900';
		height='460';
	}else{
		width='640';
		height='360';	
	}
	
	var txtCambiado = '';
	if((txt.toLowerCase()).indexOf('width') != -1) {
		while((txt.toLowerCase()).indexOf('width') != -1) {
			var posIni = posInicio( txt, 'width');
			var posFin = posFinal( txt, posIni );
			txtCambiado += txt.substring(0, posIni) + width;
			txt = txt.substring(posFin);
		}
		txt = txtCambiado + txt;
	} else {
		txt = seteaAltoAncho(txt, 'width', width); 
	}
	txtCambiado = '';
	if((txt.toLowerCase()).indexOf('height') != -1) {
		while((txt.toLowerCase()).indexOf('height') != -1) {
			var posIni = posInicio( txt, 'height');
			var posFin = posFinal( txt, posIni );
			txtCambiado += txt.substring(0, posIni) + height;
			txt = txt.substring(posFin);
		}
		txtCambiado += txt;
	} else {
		txtCambiado = seteaAltoAncho(txt, 'height', height); 
	}
	
	return txtCambiado;				
}
function posInicio( txt, txt2 ) {
	var posIni = (txt.toLowerCase()).indexOf(txt2) + txt2.length;
	var aux;
	var continuar = true;
	while( continuar ) {
		aux = txt.charAt(++posIni);
		if( aux >= 0 && aux <= 9 ) {
			continuar = false;
		}
	}
	return posIni;
}
function posFinal( txt, pos ) {
	var posFin = pos;
	var aux;
	var continuar = true;
	while( continuar ) {
		aux = parseInt(txt.charAt(++posFin));
		if( isNaN(aux) ) {
			continuar = false;
		}
	}
	return posFin;
}
function seteaAltoAncho(txt, tipo, valor) {
	if( (txt.toLowerCase()).indexOf('object') != -1 ) {
		txt = txt.substring(0, ((txt.toLowerCase()).indexOf('object') + 6)) + ' ' + tipo + '="' + valor + 'px"' + txt.substring((txt.toLowerCase()).indexOf('object') + 6);  
	}
	if( (txt.toLowerCase()).indexOf('embed') != -1 ) {
		txt = txt.substring(0, ((txt.toLowerCase()).indexOf('embed') + 5)) + ' ' + tipo + '="' + valor + '"' + txt.substring((txt.toLowerCase()).indexOf('embed') + 5);  
	}
	if( (txt.toLowerCase()).indexOf('iframe') != -1 ) {
		if( (txt.toLowerCase()).indexOf('style') != -1 ) {
			txt = txt.substring(0, ((txt.toLowerCase()).indexOf('iframe="') + 8)) + ' ' + tipo + ':' + valor + 'px;' + txt.substring((txt.toLowerCase()).indexOf('iframe') + 8); 
		} else {
			txt = txt.substring(0, ((txt.toLowerCase()).indexOf('iframe') + 6)) + ' ' + 'style="' + tipo + ':' + valor + 'px;"' + txt.substring((txt.toLowerCase()).indexOf('iframe') + 6); 
		}
	}
	return txt;
}

//function isVideoBC(video) {
	//bVideoBC = true;
	//if(typeof video=="undefined" || ((video.toLowerCase().indexOf('rc@') == -1) && isNaN(video)))bVideoBC = false;
	//return bVideoBC;
//}

function getXMLHttpRequest()
{
	var xhr;
	if (window.XMLHttpRequest)
	{
		//El explorador implementa la interfaz de forma nativa
		xhr = new XMLHttpRequest();
	} 
	else if (window.ActiveXObject)
	{
		//El explorador permite crear objetos ActiveX
		try {
			xhr = new ActiveXObject("MSXML2.XMLHTTP");
		} catch (e) {
			try {
				xhr = new ActiveXObject("Microsoft.XMLHTTP");
			} catch (e) {}
		}
	}
	if (!xhr)
	{
		alert("No ha sido posible crear una instancia de XMLHttpRequest");
	}
	return xhr;
}

function getVideoObject(site,medio,sVideo, iWidth, iHeight, iIdPlayer, sEnlace, sPie, sEntradilla, iIdComentarios, iIdModal, imgPatrocinio, urlPatrocinio, clickcommand, redesSociales, autor, apoyoTexto, apoyoURL, antetituloTexto, comentarios, idRefencia) {
	if(sEnlace != '' && !(sEnlace.toLowerCase().indexOf('http://') != -1)) {
		sEnlace = "http://"+ document.domain + sEnlace;
	}
	var s1 = '';
	//alert ('MODAL');
	s1 += '<div class="player-modal-t">';
	s1 += '<div class="player-modal-b">';
	s1 += '<div class="contenedor-modal">';
	if (imgPatrocinio != '' && urlPatrocinio != '' ) {
		s1 += '<div class="patrocinio">Patrocinado por: <a href="' + urlPatrocinio + '" target="_new" ><img src="' + imgPatrocinio + '" /></a></div>';
	}
	s1 += '<div class="cerrar"><a href="javascript:void(0)" class="simplemodal-close">Cerrar</a></div>';
	s1 += '<div class="centradoVideoModal" id="capaVideo_'+sVideo+'">';
	s1 += getEmbedVideo(site,medio,null, sVideo, iWidth, iHeight, iIdPlayer, idRefencia);
	s1 += '</div>';
	if(autor!= '')s1 +='<div class="photo-caption">Autor: '+autor+'</div>'
	if ((antetituloTexto != null) && (antetituloTexto != '')) {
		s1 += '<div class="overhead">' + antetituloTexto + '</div>';
	}
	else {
		s1 += '<div class="overhead"></div>'
	}
	if(sEnlace != '') {
		s1 += '<h3><a class="enlaceNoticia" href="'+sEnlace+'">'+sPie+'</a></h3>';
	} else {
		s1 += '<h3><a>'+sPie+'</a></h3>';
	}
	s1 += '<div class="subhead">'+recortaCaracteres(sEntradilla, 200)+'</div>';
	if ((apoyoTexto != null) && (apoyoTexto != '') && (apoyoURL != null) && (apoyoURL != '')) {
		s1 += '<h4 class="apoyo"><a href="' + apoyoURL + '">' + apoyoTexto + '</a></h4>';
	}
	s1 += '<div class="player-pie clearfix">';
	if(redesSociales != 'false' && sEnlace != '') {
		sPie = sPie.replace(/"/g, "&quot;");
		sPie = sPie.replace(/'/g, "\'");
		s1 += '<div class="redes-sociales">';
		s1 += '<iframe scrolling="no" frameborder="0" allowtransparency="true" src="http://www.facebook.com/plugins/like.php?href='+sEnlace+'&layout=button_count&show_faces=true&width=120&action=recommend&font=arial&colorscheme=light&height=21"></iframe>';
		s1 += '<a href="http://twitter.com/share" class="twitter-share-button" data-url="'+sEnlace+'" data-text="'+sPie+'" data-count="horizontal">Tweet</a><script type="text/javascript" src="http://platform.twitter.com/widgets.js"></script>'
		s1 += '<a target="_blank" href="http://www.tuenti.com/share?url='+sEnlace+'">';
		s1 += '<img src="/img/tuentishare_button22_ca.png" alt="Compartir tuenti"/>';
		s1 += '</a>';
		s1 += '</div>';
		if(comentarios != 'false' && comentarios != '') {
		s1 += '<a class="num_comentarios" href="'+sEnlace+'#opina" onclick="javascript:closeComentarios();">';
		s1 += '<span id="num-comentarios-'+iIdComentarios+'">Comenta esta noticia</span>';
		s1 += '</a>';}
	}
	s1 += '</div></div></div></div>';
	return s1;
}

function getEmbedVideo(site,medio,layer, sVideo, iWidth, iHeight, iIdPlayer, idReferencia ) {
	if (!DetectSmartphone()) {
		var s1 = '';
		
		s1 += '<object id="flashObj-'+sVideo+'" width="'+iWidth+'" height="'+iHeight+'" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,47,0">';
		//s1 += '<object id="flashObj-'+sVideo+'" width="100%" height="100%" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,47,0">';
		s1 += '<param name="movie" value="http://c.brightcove.com/services/viewer/federated_f9/'+iIdPlayer+'?isVid=1&isUI=1" />';
		s1 += '<param name="bgcolor" value="#000000" />';
		if(idReferencia.indexOf('MP-') != -1) {
			s1 += '<param name="flashVars" value="@videoPlayer='+sVideo+'&playerID='+iIdPlayer+'&domain=embed&dynamicStreaming=true&autoStart=true&videoSmoothing=true" />';
		}else{
			s1 += '<param name="flashVars" value="@videoPlayer='+sVideo+'&playerID='+iIdPlayer+'&domain=embed&dynamicStreaming=true&autoStart=true" />';
		}
		s1 += '<param name="base" value="http://admin.brightcove.com" />';
		s1 += '<param name="seamlesstabbing" value="false" />';
		s1 += '<param name="allowFullScreen" value="true" />';
		s1 += '<param name="swLiveConnect" value="true" />';
		s1 += '<param name="wmode" value="transparent" />';
		s1 += '<param name="allowScriptAccess" value="always" />';
		s1 += '<embed src="http://c.brightcove.com/services/viewer/federated_f9/'+iIdPlayer+'?isVid=1&isUI=1" bgcolor="#000000" ';
		if(idReferencia.indexOf('MP-') != -1) {
			s1 += 'flashVars="@videoPlayer='+sVideo+'&playerID='+iIdPlayer+'&&domain=embed&dynamicStreaming=true&autoStart=true&videoSmoothing=true" ';
		}else{
			s1 += 'flashVars="@videoPlayer='+sVideo+'&playerID='+iIdPlayer+'&&domain=embed&dynamicStreaming=true&autoStart=true" ';
		}
		//MODIFICADO POR JSJ
		//s1 += 'base="http://admin.brightcove.com" name="flashObj" width="'+iWidth+'" height="'+iHeight+'" seamlesstabbing="false" ';
		s1 += 'base="http://admin.brightcove.com" name="flashObj-'+sVideo+'" width="'+iWidth+'" height="'+iHeight+'" seamlesstabbing="false" ';
		s1 += 'type="application/x-shockwave-flash" allowFullScreen="true" allowScriptAccess="always" swLiveConnect="true" wmode="transparent"';
		s1 += 'pluginspage="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash">';
		s1 += '</embed>';
		s1 += '</object>';		
		
		return s1;

	} else {
		var sMobile = makeMobileCompatible(site,medio,layer ? layer : "capaVideo_" + sVideo, sVideo, iIdPlayer, sVideo, iWidth, iHeight, null);
		return sMobile;
	}
}

function recortaCaracteres(text, limit) {
	//Modificado por Diego ;-)
	//Hay que limpiar el html antes de recortar
	text = strip_tags(text);
	
	if(text.length > limit) {
		if(text.charAt(limit) != ' ' && text.charAt(limit) != '') {
			var chars = izqDer(text, limit);
			if(chars > 0) {
				return text.substring(0, limit+chars) + "...";
			} else if(chars < 0){
				return text.substring(0, limit+chars) + "...";
			} else {
				return text.substring(0, limit) + "...";
			}
		} else {
			if(text.charAt(limit-4) != ' ' && text.charAt(limit-4) != '') {
				return text.substring(0, limit) + "...";
			} else {
				return text.substring(0, limit-5) + "...";
			}
		}
		return text
	} else {
		return text;
	}
}
function izqDer(text, limit) {
	var auxMas = 0;
	var auxMen = 0;
	do{
		auxMas++;
	}while(text.charAt(limit+auxMas) != ' ' && text.charAt(limit+auxMas) != '' );
	do{
		auxMen++;
	}while(text.charAt(limit-auxMen) != ' ' && text.charAt(limit+auxMas) != '' );
	if(auxMas<=auxMen && auxMas > 0) {
		return auxMas;
	} else if(auxMas>auxMen && auxMen > 0) {
		return auxMen * -1;
	} else {
		return 0;
	}
}

function getIdWMPlayer(txt) {
	if(txt.indexOf('microsoft') != -1) {
		var aux1 = txt.substring(txt.indexOf('<object'));
		var aux2 = aux1.substring(aux1.indexOf(' id="')+5);
		idWMPlayer = aux2.substring(0, aux2.indexOf('"'));
	} else {
		idWMPlayer = '';
	}
}
function stopplayer() {
	if (window.ActiveXObject != null && idWMPlayer != '') (document.getElementById(idWMPlayer)).controls.stop();
}

function gaweb() {
	dominiosWebTV=['www.elcorreo.com/videos','www.diariovasco.com/videos','www.nortecastilla.es/videos','www.elnortedecastilla.es/videos','www.eldiariomontanes.es/videos','www.elcomerciodigital.com/videos','www.elcomercio.es/videos','www.hoy.es/videos','www.ideal.es/videos','www.larioja.com/videos','www.lavozdigital.es/videos','www.lasprovincias.es/videos','www.laverdad.es/videos','www.diariosur.es/videos','www.abc.es/videos','www.abcdesevilla.es/videos'];
	
	for (i=0;i<dominiosWebTV.length;i++){ 
		var pos=document.URL.indexOf(dominiosWebTV[i]);
		if (pos>=0){
			return 'WebTV';
		}	
	}
	
	dominios=['elcorreo.com','diariovasco.com','nortecastilla.es','elnortedecastilla.es','eldiariomontanes.es','elcomerciodigital.com','elcomercio.es','hoy.es','ideal.es','larioja.com','lavozdigital.es','lasprovincias.es','laverdad.es','diariosur.es','abc.es','abcdesevilla.es'];
	
	for (i=0;i<dominios.length;i++){ 
		var pos=document.domain.indexOf(dominios[i]);
		if (pos>=0){
			return 'Embebido';
		}
	} 
	
	return 'Otros';	
}

function getTagsPatrocinados (idPortal) {
	var patrocinados = tagsPatrocinados[idPortal];
	return patrocinados;
}

function isTagPatrocinado (idPortal, tag) {
	var encontrado = false;
	var patrocinados = getTagsPatrocinados (idPortal);
	if (patrocinados != null) {
		for (var i = 0; (i < patrocinados.length) && !encontrado; i++) {
			if (patrocinados[i] == tag) encontrado = true;
		}	
	}
	return encontrado;
}

function getDatosTagPatrocinado (idPortal, tag) {
	if (isTagPatrocinado(idPortal, tag)) {
		return tagsPatrocinados[idPortal][tag];
	}
	else  {
		return null;
	}
}

function closeComentarios() {
	$.modal.impl.close();
}

function getThumbBC(div, site) {
	var idVideo = div.substring(0, div.indexOf('-'));
	var sEnlace = "";
	var sTitulo = "";
	var sVideoStillURL = "";
	var adTags;
	var sURLDataBC = '';
	if(isNaN(idVideo)) {
		if(idVideo.indexOf('rc@') != -1) idVideo = idVideo.substring(idVideo.indexOf('@')+1);
		sURLDataBC = '/includes/manuales/webtv/phpproxy/phpproxy.php?medio='+ PlayerWebTV.INFO_PORTALES[site].medio +'&command=find_video_by_reference_id&video_fields=name,linkURL,videoStillURL,tags&reference_id='+idVideo;
	} else {
		sURLDataBC = '/includes/manuales/webtv/phpproxy/phpproxy.php?medio='+ PlayerWebTV.INFO_PORTALES[site].medio +'&command=find_video_by_id&video_fields=name,linkURL,videoStillURL,tags&video_id='+idVideo;
	}
	
	if(getXMLHttpRequest()){
		$.ajax({
			url: sURLDataBC,
			dataType: 'json',
			data: null,
			async: false,
			success: function(data) {
				if (data.name!=null) sTitulo = data.name;
				if (data.linkURL!=null) sEnlace = data.linkURL;
				if (data.videoStillURL!=null) sVideoStillURL = data.videoStillURL;
				if (data.tags!=null) adTags = data.tags;
			}
		});
	}
	
	var codVideo = '<div class="photo">';
	codVideo += '<a href="'+sEnlace+'" title="'+sTitulo+'">';
	codVideo += '<img src="'+(getURLResizer(sVideoStillURL, 108, 62, 'play.png', site))+'" alt="'+sTitulo+'">';
	codVideo += '</a>';
	codVideo += '</div>';
	codVideo += '</div>';
	codVideo += '<div class="overhead">'+((adTags.length>0)?adTags[0]:"video")+'</div>';
	codVideo += '<h3>';
	codVideo += '<a href="'+sEnlace+'" title="'+sTitulo+'">'+recortaCaracteres(sTitulo, 28)+'</a>';
	codVideo += '</h3>';
	//$("#"+div+"").parent().html(codVideo);
	document.getElementById(div).parentNode.innerHTML = codVideo;
}



function getURLResizer(src, ancho, alto, marcaAgua, site) {
	var result = getFullURL(src);
	var medio = PlayerWebTV.INFO_PORTALES[site].resizer;
	if (!isDesarrolloABC()) {
		if (marcaAgua) {
			result = "http://resizer." + medio + "/resizer/resizer.php?imagen=" + result + "&nuevoancho=" + ancho + "&nuevoalto=" + alto + "&copyright=false&encrypt=false&posmarca=C&transparencia=85";
		} else {
			result = "http://resizer." + medio + "/resizer/resizer.php?imagen=" + result + "&nuevoancho=" + ancho + "&nuevoalto=" + alto + "&copyright=conCopyright&encrypt=false";
		}
	}
	return result;
}
	
function getFullURL(src) {
	if (src.indexOf("//") == -1 && !(src.charAt(0) == "/")) {
		// la ruta es relativa a la pagina
		// src = "nivel2/imagen.png"
		var ruta = location.href.substring(0, location.href.lastIndexOf("/") + 1);
		src = ruta + src;
	} else if (src.charAt(0) == "/") {
		// la ruta de la imagen es relativa al servidor, concatenamos el servidor actual
		// src = "/carpeta/imagen.png"
		src = location.protocol + "//" + location.host + src;
	}
	return src;
}





/*********************************************** CONFIGURATION ************************************************/

/**
 * This value indicates whether or not your account is set-up for UDS. HTML5 requires that the files be delivered
 * over HTTP.  This is accomplished by having an account that is configured for HTTP (PD) delivery or that is set-up
 * for UDS. 
 */
var isUDS = true;

/* This variable is a dictionary that contains information about the location of each
 * Brightcove video object within the DOM of the page. Specifically, it is an associative array
 * where, for each stored mapping, the keys is the playerID of a given video, and the value is
 * the next sibling of that video object in the DOM. Keeping track of this sibling will allow
 * us to re-insert the mobile compatible <video> tag into the correct place (before this sibling)
 * in the DOM of the original page.
 */
var pagePlacementInfo = new Object();

/**********************************************************************************************************************/
/*********************************************** DOM MODIFICATION CODE ************************************************/
/**********************************************************************************************************************/


/* This method works on a specific object, represented by id "strObjID". The method retrieves the
 * element with the given ID from the DOM, and then extracts the player ID from the video
 * object. Then, it removes the video object from the page's DOM and stores its location in the page
 * in a global dictionary variable (this will be useful when we want to add the corresponding
 * video tag back in the page in the appropriate place).
 *
 * Finally, the method submits an API Read request to the Brightcove server through the ()
 * method in order to retrieve the sepcific Video URL corresponding to the given object.
 */
function makeMobileCompatible(site,medio,strObjID, videoTagID,playerID,videoPlayer,iWidth,iHeight,sReadToken){
	//our video object (which we need to remove)
	//var vidObj = document.getElementById(strObjID);
	
	//extract the playerID of this video object before deleting it
	var vidPlayerID = playerID;//getParamValueForVidObject(vidObj, 'playerID');
	var programmedVideo = videoPlayer;//getParamValueForVidObject(vidObj, '@videoPlayer');

	//if the video player ID could not be extracted from the Source Code, for some reason,
	//then refer to the dictionary provided by the user
	if (vidPlayerID == null || typeof vidPlayerID == 'undefined'){
			vidPlayerID = BCVidObjects[strObjID];
	}
	
	return initiateMobileVideoRetrieval(site,medio,vidPlayerID, programmedVideo, sReadToken, videoTagID, strObjID,iWidth,iHeight);
}


/** 
 * This function takes an object representing a Brigthcove video embed and a particular 'parameter' that was
 * passed to the Brightcove video object and returns the parameter.
 */
function getParamValueForVidObject(vidObj, paramName) {
	//these are the children nodes of the given object in the DOM
	var childrenNodes = vidObj.childNodes;
	var tagName;
	
	//loop through all children of the video object, searching for <param> tags.
	//each time we find a <param> tag, we check whether its name is 'flashVars'.
	//if so, we store the param's value and break from the loop, otherwise we
	//continue
	for (var i = 0; i < childrenNodes.length; i++){
	    if (childrenNodes[i].nodeType != 1) {
		continue;
	    }

	    tagName = childrenNodes[i].tagName.toLowerCase();
	    if (tagName == "param"){
		if (childrenNodes[i].getAttribute("name") == paramName){
		    return childrenNodes[i].getAttribute("value");
		}
	    }
	}

	return null;
}

/**
 * Takes a string 'str' that consists of multiple arguments separated by ampersands (&),
 * and breaks it down so that it can extract and return the paramName from the string.
 */
function parseParamFromString(str, paramName) {
	var params = str.split("&"); //array of strings
	for (var i = 0; i < params.length; i++){
		if (params[i].indexOf(paramName) != -1){
			return params[i].substr(params[i].indexOf("=")+1);
		}
	}
	
	// if we could not find the param then return null
	return null;
}



/**********************************************************************************************************************/
/****************************************** MEDIA API CALLS & VIDEO TAG INSERTION *************************************/
/**********************************************************************************************************************/

/* This method calls the Brightcove Media API to get all playlists included within a particular
 * playerID.
 */
function initiateMobileVideoRetrieval(site,medio,playerID, programmedVideoID, readAPIToken, videoTagID, strObjID,iWidth,iHeight) {
	var APICall;
	var scriptNode;
	var scriptText;
	var callbackMethodName;
	//site PlayerWebTV.INFO_PORTALES[SITIO].resizer
	//medio PlayerWebTV.INFO_PORTALES[SITIO].medio
	if (programmedVideoID) {
		if(isNaN(programmedVideoID)) {
			if(programmedVideoID.indexOf('rc@') != -1) programmedVideoID = programmedVideoID.substring(programmedVideoID.indexOf('@')+1);
			APICall = 'http://' + site + '/includes/manuales/webtv/phpproxy/phpproxy.php?medio='+ medio +'&command=find_video_by_reference_id&reference_id='+programmedVideoID;
		} else {
			APICall = 'http://' + site + '/includes/manuales/webtv/phpproxy/phpproxy.php?medio='+ medio +'&command=find_video_by_id&video_id='+programmedVideoID;
		}

		if(isUDS) {
			APICall+="&media_delivery=http";
		}

		//when we make the API call, we specify a response handler (known as a callback method) that will deal with the response from
		//the Brightcove server. However, we create a customized 'callback' method for each playerID, so that when we are 'inside' the
		//callback method (after receiving the server's reponse), we will know which playerID the response corresponds to. This variable
		//stores the name (which includes the playerID) of that callback method.
		callbackMethodName = "handleJSONResponseForID"+new Date().getTime();
		scriptText = 
		"<script>function "+callbackMethodName+"(JSONResponse){" + 
		"handleVideoResponse(JSONResponse, '"+playerID+"', '"+videoTagID+"', '"+strObjID+"', '"+iWidth+"', '"+iHeight+"');"+
		"}</script>";
	}

	//NOTE: we add to the end of the body, so that we do not disrupt any of the order of the children
	//at the top of the body's DOM tree	
	//make the API call, specifying the unique callback method for this request
	var sScript = addScriptTag("getMobileRendition", APICall, callbackMethodName);
	return scriptText + sScript;
}

/* Methods needed to make API Calls to the Brightcove server*/
function addScriptTag(id, url, callback) {
	
	var root = document.createElement ("span");
	//var elemento = document.createElement ("script");
	var scriptTag = document.createElement("script");
	var noCacheIE = '&noCacheIE=' + (new Date()).getTime();
   
	// Add script object attributes
	scriptTag.setAttribute("type", "text/javascript");
	scriptTag.setAttribute("charset", "utf-8");
	scriptTag.setAttribute("src", url + "&callback=" + callback + noCacheIE);
	scriptTag.setAttribute("id", id);

	root.appendChild(scriptTag);
	return root.innerHTML;	
	
}

/**
 * This is the general response-handler for the JSON response from the Brightcove server for playlist based players.
 * The arguments to the method include the response object, as well as the playerID of the 
 * object which this response pertains to.
 *
 */
function handleVideoResponse(JSONResponse, playerID, videoTagID, strObjID,iWidth,iHeight) {
	document.getElementById(strObjID).innerHTML = embedHTML5PlayerForVideo(JSONResponse, playerID, videoTagID, strObjID,iWidth,iHeight);
}

/** 
 * For a given video object (from the BC APIs) we will embed an HTML 5 'video' tag.
 * Requires searching through the renditions associated with the video object
 * for a rendition that is a 'best' match and passing the URL to the video
 * tag.
 *
 * In this handler, we explore the JSON object in search of the first video in the
 * first playlist that is returned by the Brightcove server. Then, once we identify
 * this first video, we examine the various renditions of the video and search
 * for the rendition that is most appropriate for a mobile (H.264 encoding 
 * and 256 kbps). 
 */
function embedHTML5PlayerForVideo(video, playerID, videoTagID, strObjID,iWidth,iHeight) {
	//obtain the array of various renditions that exist for this video.
	//NOTE: a rendition, from our perspective, has a certain encoding rate,
	//      and a certain encoding format. We wish to find the best rendition for
	//      a smartphone.
	var renditions = video.renditions;
	
	//In the for-loop that follows, we traverse all renditions of this first video, searching
	//for the H.264 (mobile-compatible) rendition whose encoding rate is closest to 256kbps
	var bestRenditionIndex = -1;
	var bestEncodingRateSoFar = -1;
	
	for (var i = 0; i < renditions.length; i = i+1){
		//if this rendition is not H264, skip it and move on to the next
		if (renditions[i].videoCodec != "H264"){
			continue;
		}
		
		//if best rendition index variable is uninitialized, then initialize it to
		//this rendition (which is H.264) - we need this because it's possible that
		//there are no H264 renditions at all, and starting our bestRenditionIndex at
		//an invalid value will help us figure out whether we came across any H264 renditions
		//as we were looping.
		if (bestRenditionIndex == -1){
			bestRenditionIndex = i;
			bestEncodingRateSoFar = renditions[i].encodingRate;
		}
		
		//otherwise check to see if this rendition has a better encoding rate than the best one before this
		else if (betterEncodingForMobile(renditions[i].encodingRate, bestEncodingRateSoFar) == renditions[i].encodingRate){
			//if so, then record this rendition as the best one so far
			bestRenditionIndex = i;
			bestEncodingRateSoFar = renditions[i].encodingRate;
		}
	}
	//after the for-loop has terminated, if best rendition index still == -1,
	//then that means we don't have ANY H264 renditions. so let the user know,
	//and don't add anything to the page
	if (bestRenditionIndex == -1){
	    bestRendition = video.videoFullLength;
	}
	else {
		bestRendition = renditions[bestRenditionIndex];
	}
	var bestRenditionURL = bestRendition.url;
	var vidName = video.name;
	var vidHeight = iHeight;//bestRendition.frameHeight;
	var vidWidth = iWidth;//bestRendition.frameWidth;
	var vidStillURL = video.videoStillURL;
	//construct the <video> tag as a DOM element
	//var videoScriptTag = formVideoTagFromInfo(videoTagID, vidName, bestRenditionURL, vidWidth, vidHeight, vidStillURL);	
	var isModal = (strObjID.match(/^.*\.photo-center$/)!=null );
	//alert (isModal);
	var videoScriptTag = formVideoTagFromInfo(videoTagID, vidName, bestRenditionURL, vidWidth, vidHeight, vidStillURL, isModal);	
	return videoScriptTag;
}

/* This function takes two encoding rates and returns the one that
 * is more apprporiate for mobile phones.
 */
function betterEncodingForMobile(encoding1, encoding2){
	IDEAL_ENCODING_RATE = 256000; //bits per second; equivalent to 256 kbps
	diff1 = Math.abs(encoding1 - IDEAL_ENCODING_RATE);
	diff2 = Math.abs(encoding2 - IDEAL_ENCODING_RATE);
	return ((diff1 <= diff2) ? encoding1 : encoding2);
}

/**
 * This method takes properties of a video, its dimensions, and its poster (still image),
 * inserts them into an HTML 5.0 <video> tag. This <video> object is then returned.
 */
function formVideoTagFromInfo(videoTagID, videoID, videoURL, vidWidth, vidHeight, vidImageURL,isModal){
	var idVideo = null;
	if (videoTagID) {
	    idVideo = videoTagID;
	}
	else {
	    idVideo = videoID;
	}
	var sReturn = '<video ';
	sReturn += 'height="'+vidHeight+'" width="'+vidWidth+'" id="'+idVideo+'" ';
	sReturn += 'poster="'+vidImageURL+'" ';
	sReturn += 'controls="true" autoplay="autoplay" ';
	if (isModal) {
		sReturn += 'onloadstart=abrirModalRetardado("' + relidGlobal + '");this.play(); ';
	}
	sReturn +='src="'+videoURL+'" >';
	sReturn += '</video>';
	return sReturn;
}
//Modificado por Diego ;-)
//Función de limpieza de html
function strip_tags (input, allowed) {
	 allowed = (((allowed || "") + "")
			.toLowerCase()
			.match(/<[a-z][a-z0-9]*>/g) || [])
			.join(''); // making sure the allowed arg is a string containing only tags in lowercase (<a><b><c>)
	 var tags = /<\/?([a-z][a-z0-9]*)\b[^>]*>/gi,
			 commentsAndPhpTags = /<!--[\s\S]*?-->|<\?(?:php)?[\s\S]*?\?>/gi;
	 return input.replace(commentsAndPhpTags, '').replace(tags, function($0, $1){
			return allowed.indexOf('<' + $1.toLowerCase() + '>') > -1 ? $0 : '';
	 });
}

/*NEW PLAYER*/
function loadMultimediaSinFoto( video, opciones ) { // Metodo que se utiliza para enlazar el video a la capa Ver Video de methode
	if(opciones == null || opciones == undefined){
		opciones = '';
	}
	
	//ESPECIFICO GRADA360
	if(opciones.site == 'grada360')	
		opciones.idModulo = 'VOC_playerGrada360';
	//FIN ESPECIFICO GRADA360	
	opciones = {
		modoExtendido: "player",
		idModulo: (opciones.idModulo == undefined) ? 'VOC_playerVideo' : opciones.idModulo,

		medio: (opciones.site == undefined) ? '' : opciones.site,
		
		edicionLocal: (opciones.edicionLocal == undefined) ? '' : opciones.edicionLocal,
		
		idDivVideo: (opciones.idDivVideo == '' || opciones.idDivVideo == undefined) ? '' : opciones.idDivVideo,
		//idVideo: RUTA_VIDEO,
		idVideo: video,
		origenVideo: (opciones.origenVideo == '' || opciones.origenVideo == undefined) ? 'bc' : opciones.origenVideo,
 		nameVideo: (opciones.titulo == undefined) ? '' : opciones.titulo,
 		linkURLVideo: (opciones.urlTitulo == undefined) ? '' : opciones.urlTitulo,
 		longDescriptionVideo: (opciones.entradilla == undefined) ? '' : opciones.entradilla,
 		shortDescriptionVideo: (opciones.entradilla == undefined) ? '' : opciones.entradilla,
 		widthVideo: 640,
 		heightVideo: 360,
 		stillURLVideo: (opciones.stillURLVideo == undefined) ? '' : opciones.stillURLVideo,
 		
 		apoyoTexto: (opciones.apoyoTexto == undefined) ? '' : opciones.apoyoTexto,
		apoyoURL: (opciones.apoyoURL == undefined) ? '' : opciones.apoyoURL,
		antetituloTexto: (opciones.antetituloTexto == undefined) ? '' : opciones.antetituloTexto,

		capaModal: (opciones.capaModal == undefined) ? false : opciones.capaModal,
		publicidadOn: (opciones.publicidadOn == undefined) ? true : opciones.publicidadOn,
		comentarios: (opciones.comentarios == undefined) ? '' : opciones.comentarios,
		redesSociales: (opciones.redesSociales == undefined) ? true : opciones.redesSociales,

		imgPatrocinio: (opciones.imgPatrocinio == undefined) ? '' : opciones.imgPatrocinio,
		urlPatrocinio: (opciones.urlPatrocinio == undefined) ? '' : opciones.urlPatrocinio,
		clickcommand: (opciones.clickcommand == undefined) ? '' : opciones.clickcommand,
		
		usoResizer: (opciones.usoResizer == undefined) ? true : opciones.usoResizer,
		
		classVideo: (opciones.classVideo == undefined) ? '' : opciones.classVideo,
		
		autoStartVideo: (opciones.autoStartVideo == undefined) ? true : opciones.autoStartVideo
	    };

	if(opciones.origenVideo == 'methode')
		opciones.origenVideo = 'bc';
	if (typeof (OAS_sitepage) == "undefined")
		var  OAS_sitepage = '';
	opciones.inskin = getInskin(OAS_sitepage);
	opciones.charset = getCharset();
	opciones.location = location.host;
	
	var idVideo = opciones.idVideo;
	if (idVideo.indexOf("RC-")!=-1 || idVideo.indexOf("rc-")!=-1 || idVideo.indexOf("RC@")!=-1 || idVideo.indexOf("rc@")!=-1){
		idVideo = idVideo.substring(3, idVideo.length);	
	}
	opciones.idVideo = idVideo;

	if(opciones.idDivVideo == '' || opciones.idDivVideo == undefined){
		idDivVideo = 'ver_video_' + opciones.idVideo;
		//idDivVideo = opciones.idVideo;
		opciones.idDivVideo = idDivVideo;
	}
	
	var playerVideoDomain = playerVideoGetDomain(opciones.medio);
	playerVideoDomain = playerVideoDomain.replace("http://", "").replace("www.", "").replace("www-origin.", "");
	var url = 'http://modulos-mm.' + playerVideoDomain + '/includes/manuales/videos/php/proxyModgen.php';
	//var url = 'http://194.30.12.10/includes/manuales/videos/php/proxyModgen_v2.php';
	//var url = 'http://modgen-pre.vocento.com/includes/manuales/videos/php/proxyModgen_v2.php';
	//var url = 'http://' + opciones.location + '/includes/manuales/videos/php/proxyModgen_v2.php';
	var url = url + '?'; 

	urlTemp = ''; 
	for (key in opciones){
		var value = "" + opciones[key];
		if(value != "")
			urlTemp = urlTemp + key + '=' + escape(value) + '&';
	}
	url = url + urlTemp.substring(0, urlTemp.length -1);


	if (jQuery.browser.msie && parseInt(jQuery.browser.version, 10) < 8) {
		jQuery.support.cors = true;
		var rpc = new easyXDM.Rpc({
							        remote: "http://modulos-mm." + playerVideoDomain + "/cors.html"
							    },
							    {
							        remote: {
							            	request: {}
							        		}
							    });
		rpc.request({
				        url: url.replace("http://modulos-mm." + playerVideoDomain, ""),
				        method : "GET"
				    }, function(response) {
								        var data = response.data;
								        javascriptOpciones = data.substring(0, data.indexOf('</script>') + 9);
										javascriptOpciones = javascriptOpciones.substring(javascriptOpciones.indexOf('<script'), javascriptOpciones.length);
										
										var idDivVideo = opciones.idDivVideo;
										var jQueryIdVideo = '#'+ idDivVideo;
										var idOpciones = idVideo.replace(/\./g, '_').replace(/-/g, '_');
										var idDivModal = idDivVideo.replace(/\./g, '-') + "-_-modal";
										var jQueryIdDivModal = '#ver_video_'+ idDivModal;
										var ver_video = jQuery(jQueryIdDivModal, data).html();
										jQuery(jQueryIdVideo).html(javascriptOpciones + ver_video);
										jQuery(jQueryIdVideo).append('<div id=' + idDivVideo + '-_-modal style="display:none;"></div>');
				    });
	}else if (jQuery.browser.msie && parseInt(jQuery.browser.version, 10) >= 8 && window.XDomainRequest) {
        // Use Microsoft XDR
        var xdr = new XDomainRequest();
        xdr.open("get", url);
        xdr.onload = function() {
				                // XDomainRequest doesn't provide responseXml, so if you need it:
				                var dom = new ActiveXObject("Microsoft.XMLDOM");
				                dom.async = false;
				                //alert("XDR Response *" + xdr.responseText + "*");
				                //dom.loadXML(xdr.responseText);
				                var data = xdr.responseText;
				                javascriptOpciones = data.substring(0, data.indexOf('</script>') + 9);
								javascriptOpciones = javascriptOpciones.substring(javascriptOpciones.indexOf('<script'), javascriptOpciones.length);
								
								var idDivVideo = opciones.idDivVideo;
								var jQueryIdVideo = '#'+ idDivVideo;
								var idOpciones = idVideo.replace(/\./g, '_').replace(/-/g, '_');
								var idDivModal = idDivVideo.replace(/\./g, '-') + "-_-modal";
								var jQueryIdDivModal = '#ver_video_'+ idDivModal;
								var ver_video = jQuery(jQueryIdDivModal, data).html();
								jQuery(jQueryIdVideo).html(javascriptOpciones + ver_video);
								jQuery(jQueryIdVideo).append('<div id=' + idDivVideo + '-_-modal style="display:none;"></div>');
        };
        xdr.send();
    }else{
    	if((typeof jQuery_1_8_1 == "undefined") ||  (jQuery_1_8_1 == null)){
			//jQuery.getScript('http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js', function() {
			jQuery.getScript('http://nets.abc.es/jquery/1.8.1/jquery.min.js', function() {
				jQuery_1_8_1 = jQuery.noConflict(true);
				jQuery_1_8_1.support.cors = true;
				jQuery_1_8_1.ajax({
							url: url,
							//crossDomain: true,
							dataType: "html",
							success: function(data) {
														javascriptOpciones = data.substring(0, data.indexOf('</script>') + 9);
														javascriptOpciones = javascriptOpciones.substring(javascriptOpciones.indexOf('<script'), javascriptOpciones.length);
														
														var idDivVideo = opciones.idDivVideo;
														var jQueryIdVideo = '#'+ idDivVideo;
														var idOpciones = idVideo.replace(/\./g, '_').replace(/-/g, '_');
														var idDivModal = idDivVideo.replace(/\./g, '-') + "-_-modal";
														var jQueryIdDivModal = '#ver_video_'+ idDivModal;
														var ver_video = jQuery(jQueryIdDivModal, data).html();
														jQuery(jQueryIdVideo).html(javascriptOpciones + ver_video);
														jQuery(jQueryIdVideo).append('<div id=' + idDivVideo + '-_-modal style="display:none;"></div>');
													},
							error: function(XMLHttpRequest, textStatus, errorThrown){
																					//alert("Error");
																					}
							});
			});
		}else{
			jQuery_1_8_1.support.cors = true;
			jQuery_1_8_1.ajax({
							url: url,
							//crossDomain: true,
							dataType: "html",
							success: function(data) {
														javascriptOpciones = data.substring(0, data.indexOf('</script>') + 9);
														javascriptOpciones = javascriptOpciones.substring(javascriptOpciones.indexOf('<script'), javascriptOpciones.length);
														
														var idDivVideo = opciones.idDivVideo;
														var jQueryIdVideo = '#'+ idDivVideo;
														var idOpciones = idVideo.replace(/\./g, '_').replace(/-/g, '_');
														var idDivModal = idDivVideo.replace(/\./g, '-') + "-_-modal";
														var jQueryIdDivModal = '#ver_video_'+ idDivModal;
														var ver_video = jQuery(jQueryIdDivModal, data).html();
														jQuery(jQueryIdVideo).html(javascriptOpciones + ver_video);
														jQuery(jQueryIdVideo).append('<div id=' + idDivVideo + '-_-modal style="display:none;"></div>');
													},
							error: function(XMLHttpRequest, textStatus, errorThrown){
																					//alert("Error");
																					}
							});
		}
	}
	
}
/*NEW PLAYER*/	

/*
INICIO: Metodos para pintar videos en Android
 ---------------------------------------------------------------------------
*/
function obtieneRutaMP4Video (site, medio, video, idEnlaceCapaModal) {	
	var rutaMP4 = '#';
	
	try {
		var APICall = '';

		var idVideo = video;
		if (video.indexOf('-_-') != -1) idVideo = video.split('-_-')[0];
		
		if(isNaN(idVideo)) {
			if (idVideo.indexOf('rc@') != -1) idVideo = idVideo.substring(idVideo.indexOf('@')+1);
			var APICall = 'http://' + site + '/includes/manuales/webtv/phpproxy/phpproxy.php?medio='+ medio +'&command=find_video_by_reference_id&reference_id='+idVideo;
		} else {
			APICall = 'http://' + site + '/includes/manuales/webtv/phpproxy/phpproxy.php?medio='+ medio +'&command=find_video_by_id&video_id='+idVideo;
		}
		APICall += '&media_delivery=http&json=1&callback=?';

		if(getXMLHttpRequest()){
			$.ajax({
				url: APICall,
				dataType: 'json',
				data: null,
				async: false,
				success: function(data) {
					try {
						var renditions = data.renditions;
	
						//In the for-loop that follows, we traverse all renditions of this first video, searching
						//for the H.264 (mobile-compatible) rendition whose encoding rate is closest to 256kbps
						var bestRenditionIndex = -1;
						var bestEncodingRateSoFar = -1;
						
						for (var i = 0; i < renditions.length; i = i+1){
							//if this rendition is not H264, skip it and move on to the next
							if (renditions[i].videoCodec != "H264"){
								continue;
							}
							
							//if best rendition index variable is uninitialized, then initialize it to
							//this rendition (which is H.264) - we need this because it's possible that
							//there are no H264 renditions at all, and starting our bestRenditionIndex at
							//an invalid value will help us figure out whether we came across any H264 renditions
							//as we were looping.
							if (bestRenditionIndex == -1){
								bestRenditionIndex = i;
								bestEncodingRateSoFar = renditions[i].encodingRate;
							}
							
							//otherwise check to see if this rendition has a better encoding rate than the best one before this
							else if (betterEncodingForMobile(renditions[i].encodingRate, bestEncodingRateSoFar) == renditions[i].encodingRate){
								//if so, then record this rendition as the best one so far
								bestRenditionIndex = i;
								bestEncodingRateSoFar = renditions[i].encodingRate;
							}
						}
						//after the for-loop has terminated, if best rendition index still == -1,
						//then that means we don't have ANY H264 renditions. so let the user know,
						//and don't add anything to the page
						if (bestRenditionIndex == -1){
						    bestRendition = video.videoFullLength;
						}
						else {
							bestRendition = renditions[bestRenditionIndex];
						}
						var bestRenditionURL = bestRendition.url;
						rutaMP4 = bestRenditionURL;
						$("#" + idEnlaceCapaModal).attr('href', rutaMP4);
					}catch(err){
					}
				}
			});
		}
	} 
	catch (err) {
		rutaMP4 = '#';
	}

	return rutaMP4;	
}
/*
FIN: Metodos para pintar videos en Android
 ---------------------------------------------------------------------------
*/