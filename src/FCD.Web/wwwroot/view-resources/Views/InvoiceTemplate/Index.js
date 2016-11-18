(function () {
    $(function () {

        var _invoiceTemplateService = abp.services.app.invoiceTemplate;

        $('#myTable').dataTable({
            "processing": true,
            "serverSide": true,
            "ajax": {
                "url": "/api/services/app/invoiceTemplate/GetAll",
                "type": 'POST',
                "contentType": 'application/json',
                "data": function (d) {

                    d.maxResultCount = d.length;
                    d.searchText = d.search.value;
                    d.sorting = d.columns[d.order[0].column].name + ' ' + d.order[0].dir;
                    d.skipCount = d.start;

                    return JSON.stringify(d);
                },
                "dataSrc": function (json) {

                    json.recordsTotal = json.result.totalCount;
                    json.recordsFiltered = json.result.totalCount;

                    return json.result.items;
                }
            },            
            "aoColumnDefs": [               
                {
                    "aTargets": [1],
                    //"mData": "invoiceTemplateName",
                    "mRender": function (data, type, full) {
                        console.log(full);
                        //return '<a href="/UserDetail.aspx?ID=' + data + '">Detail</a>';
                        return full.pageWidth + 'x' + full.pageHeigth;
                    }
                }//,
                //{
                //    "aTargets": [2],
                //    "mData": "id",
                //    "mRender": function (data, type, full) {
                //        return '<a href="/InvoiceTemplate/Delete/' + full.id + '">Delete</a>';
                //    }
                //}
            ],
            "aoColumns": [
                { "mData": "invoiceTemplateName", "sName": "invoiceTemplateName" },
                { "mData": "pageWidth", "sName": "pageWidth" },
                //{ "mData": "pageHeigth", "sName": "pageHeigth" }
            ]
        });

        var _$modal = $('#InvoiceTemplateCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate();

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var invoiceTemplate = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js

            abp.ui.setBusy(_$modal);
            _invoiceTemplateService.create(invoiceTemplate).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new user!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });
    });
})();