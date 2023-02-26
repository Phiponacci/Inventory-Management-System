
$(document).ready(function () {
	const datatable = $('#datatable').dataTable({
		"searching": false,
		"iDisplayLength": 10,
		"ordering": false,
		"lengthChange": false,
		"bServerSide": true,
		"processing": true,
		"paging": true,
		"sAjaxSource": "/User/List",
		"info": true,
		"fnServerData": function (sSource, aoData, fnCallback, oSettings) {
			aoData.push(
				{ "name": "returnformat", "value": "plain" },
				{ "name": "Username", "value": $('input[name="UserName"]').val() },
				{ "name": "FirstName", "value": $('input[name="FirstName"]').val() },
				{ "name": "LastName", "value": $('input[name="LastName"]').val() }
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
					mDataProp: "UserName"
				},
				{
					mDataProp: "FirstName"
				},
				{
					mDataProp: "LastName"
				},
				{
					"sDefaultContent": "",
					"bSortable": false,
					"mRender": function (data, type, row) {
						let buttons = "";
						buttons += '<a href="/User/Edit/' + row.Id + '" class="btn btn-xs btn-warning"><i class="fas fa-pen"></i> Edit</a>&nbsp;'
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

	$.ajax({
		url: '/User/Delete/' + id,
		type: "POST",
		async: false,
		success: function (data) {
			if (data.IsSucceeded) {
				const aPos = $('#datatable').dataTable().fnGetPosition(row);
				$('#datatable').dataTable().fnDeleteRow(aPos);
				toastr.success(data.UserMessage);
			}
			else {
				toastr.error(data.UserMessage);
			}
		}
	});
}

