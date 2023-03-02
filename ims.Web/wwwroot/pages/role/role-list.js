
$(document).ready(function () {
	var datatable = $('#datatable').dataTable({
		"searching": false,
		"iDisplayLength": 10,
		"ordering": false,
		"lengthChange": false,
		"bServerSide": true,
		"processing": true,
		"paging": true,
		"sAjaxSource": "/Role/List",
		"info": true,
		"fnServerData": function (sSource, aoData, fnCallback, oSettings) {
			aoData.push(
				{ "name": "returnformat", "value": "plain" },
				{ "name": "RoleName", "value": $('input[name="RoleName"]').val() }
			);
			$.ajax({
				"dataType": 'json',
				"type": "GET",
				"url": sSource,
				"data": aoData,
				"success": function (data) {
					if (data.IsSucceeded) {
						fnCallback(data);
					}
					else {
						toastr.error(data.UserMessage);
					}
				}
			});
		},
		aoColumns:
			[
				{
					mDataProp: "RoleName"
				},
				{
					"sDefaultContent": "",
					"bSortable": false,
					"mRender": function (data, type, row) {
						var buttons = "";
						buttons += '<a href="/Role/Edit/' + row.Id + '" class="btn btn-xs btn-warning"><i class="fas fa-pen"></i> Edit</a>&nbsp;'
						buttons += '<a onclick="deleteRow(this,' + row.Id + ')"  class="btn btn-xs btn-danger"><i class="fas fa-trash"></i> Delete</a>'
						return buttons;
					}
				}
			]
	});

	$("#btnFilter").click(function () {
		datatable.fnFilter();
	});

	$("#btnClear").click(function () {
		$('div.dataTable-search-form').clearForm();
		datatable.fnFilter();
	});


	$('.enter-keyup').keypress(function (event) {
		const keycode = (event.keyCode ? event.keyCode : event.which);
		if (keycode == '13') {
			datatable.fnFilter();
		}
	});

});



function deleteRow(row, id) {
	Swal.fire({
		title: 'Are you sure?',
		text: "You won't be able to revert this!",
		icon: 'warning',
		showCancelButton: true,
		confirmButtonColor: '#3085d6',
		cancelButtonColor: '#d33',
		confirmButtonText: 'Yes, delete it!'
	}).then((result) => {
		if (result.isConfirmed) {
			$.ajax({
				url: '/Role/Delete/' + id,
				type: "POST",
				async: false,
				success: function (data) {
					if (data.IsSucceeded) {
						const aPos = $('#datatable').dataTable().fnGetPosition(row);
						$('#datatable').dataTable().fnDeleteRow(aPos);
						Swal.fire(
							'Deleted!',
							'',
							'success'
						)
					}
					else {
						Swal.fire(
							'Not deleted!',
							'',
							'error'
						)
					}
				}
			});

		}
	})
}

