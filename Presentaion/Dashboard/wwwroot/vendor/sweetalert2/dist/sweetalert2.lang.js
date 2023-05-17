if(document.body.classList.contains('rtl')){
}
if(document.getElementsByTagName("html")[0].getAttribute("dir")=='rtl'){
	swal = Swal =  Swal.mixin({
		confirmButtonText:'موافق',
		cancelButtonText:'الغاء'
	});
}