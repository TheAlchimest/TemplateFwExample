var DataTableHelper = {
    difinColumn: function (index, visible, searchable) {
        return {
            "targets": index,
            "visible": visible,
            "sortable": searchable,
            "searchable": searchable
        };
    },
    difineUnsearchableColumn: function (index) {
        return DataTableHelper.difinColumn(index, true, false);
    },
    indexColumn: {
        "render": function (data, type, row, meta) {
            return (meta.row + 1);
    } },
  renderActionsColumn: function (actions, apiUrl, primaryKey) {
    return {
            "render": function (data, type, row, meta) {
                
                return DataTableHelper.drawActionsDataTable(row[primaryKey], actions, apiUrl, loadData);
            }
        };
    },
    drawActionsDataTable: function (id, actions, apiUrl, deleteCallback) {
        
        let html = "";

        const viewUrl = `${apiUrl}/view/${id}`;
        const editUrl = `${apiUrl}/edit/${id}`;
        const deleteUrl = `${apiUrl}/delete/${id}`;
        const resultsUrl = `${apiUrl}/results/${id}`;
        const actionsArray = actions.split(",");

        actionsArray.forEach(function (action, index) {
            switch (action) {
                case 'view':
                    html += `<a href='${viewUrl}' class='btn btn-brand btn-elevate btn-icon btn-sm' title=''><i id='${id}'  class='la la-eye' > </i></a>`;
                    break;
                case 'edit':
                    html += `<button type='button' class='btn btn-primary shadow btn-xs sharp mr-1'><a href='${editUrl}' title=''><i id='${id}' class='fa fa-pencil'></i></a></button>`;
                    break;
                case 'delete':
                    html += `<button class='btn btn-danger shadow btn-xs sharp' onClick=\"return deleteObj('${id}',this,'${deleteUrl}',${deleteCallback})\" title=''><i id=${id}'  class='fa fa-trash' > </i></button>`;
                    break;
                case "results":
                    html += `<button type='button' class='btn btn-primary shadow btn-xs sharp mr-1'><a href='${resultsUrl}' title=''><i id='${id}' class='fa fa-pencil'></i></a></button>`;
                    break;
                case 'open/stop':
                    html += ``;
                    break;

                default:
            }
        });

        return html;
    },
    addColumn: function (columnName) {
        var smallColumnName = StringHelper.lowerFirstLetter(columnName);
        return { "data": smallColumnName, "name": columnName, "autoWidth": true }
    },
    renderColumnsObjects: function (columnsNames, actions, apiUrl, primaryKey) {
        //let columnsAttr = "#,Question,Portal,Service,Created";
        let columns = {
            defs: [],
            cols: []
        };
        columnsNames.forEach(function (column, index) {
            switch (column) {
                case '#':
                    columns.defs.push(DataTableHelper.difineUnsearchableColumn(index));
                    columns.cols.push(DataTableHelper.indexColumn);
                    break;
                case 'Created':
                    columns.defs.push(DataTableHelper.difineUnsearchableColumn(index));
                    columns.cols.push(DataTableHelper.addColumn(column));
                    break;
                case '#Actions':
                    columns.defs.push(DataTableHelper.difineUnsearchableColumn(index));
                    columns.cols.push(DataTableHelper.renderActionsColumn(actions, apiUrl, primaryKey));
                    break;
                default:
                    columns.cols.push(DataTableHelper.addColumn(column));
                    break;
            }
        });
        return columns;
    },

    render: function ($datatable, query = "") {
        const primaryKey = $datatable.data('pk');
        const apiUrl = $datatable.data('url');
        const actions = $datatable.data('actions');
        const columnsAttr = $datatable.data('fields');
        const columnsArray = columnsAttr.split(",");
        const columns = DataTableHelper.renderColumnsObjects(columnsArray, actions, apiUrl, primaryKey);
        const options = {
            language: {
                url: langFileUrl
            },
            "processing": true,
            "serverSide": true,
            "filter": true,
            "ajax": {
                "url": `${apiUrl}/LoadAll${query}`,
                "type": "POST",
                "datatype": "json"
            },
            "columns": columns.cols,
            "columnDefs": columns.defs
        };
        console.log(options);
        $datatable.DataTable(options);
    }
};
