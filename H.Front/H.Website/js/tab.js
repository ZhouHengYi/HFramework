function taba_dturn(thisObj,Num){
	if(thisObj.className =="onclick")
		return;
	var liObj = thisObj.parentNode.id;
	var tabList = document.getElementById(liObj).getElementsByTagName("li");
	for(i=0; i <tabList.length; i++){
		if (i == Num){
			tabList[i].className = "onclick";
			document.getElementById("taba_"+i).style.display=""
		}else{
			tabList[i].className = ""; 
			document.getElementById("taba_"+i).style.display="none"
		}
	} 
}

function tabb_dturn(thisObj,Num){
	if(thisObj.className =="onclick")
		return;
	var liObj = thisObj.parentNode.id;
	var tabList = document.getElementById(liObj).getElementsByTagName("li");
	for(i=0; i <tabList.length; i++){
		if (i == Num){
			tabList[i].className = "onclick";
			document.getElementById("tabb_"+i).style.display=""
		}else{
			tabList[i].className = ""; 
			document.getElementById("tabb_"+i).style.display="none"
		}
	} 
}


/*
function tabb_dturn(thisObj,Num){
	if(thisObj.className =="hover")
		return;
	var liObj = thisObj.parentNode.id;
	var tabList = document.getElementById(liObj).getElementsByTagName("li");
	for(i=0; i <tabList.length; i++){
		if (i == Num){
			tabList[i].className = "hover";
			document.getElementById("tabb_"+i).style.display=""
		}else{
			tabList[i].className = ""; 
			document.getElementById("tabb_"+i).style.display="none"
		}
	} 
}



function tabc_dturn(thisObj,Num){
	if(thisObj.className =="hover")
		return;
	var liObj = thisObj.parentNode.id;
	var tabList = document.getElementById(liObj).getElementsByTagName("li");
	for(i=0; i <tabList.length; i++){
		if (i == Num){
			tabList[i].className = "hover";
			document.getElementById("tabc_"+i).style.display=""
		}else{
			tabList[i].className = ""; 
			document.getElementById("tabc_"+i).style.display="none"
		}
	} 
}

*/