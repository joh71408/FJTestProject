var datatables = {
    paging: true,
    searching: false,
    ordering: true,
    lengthChange: true,
    language: {

        lengthMenu: '<label>顯示</label><select class="custom-select custom-select-sm form-control form-control-sm">' + '<option value="10">10</option>' + '<option value="20">20</option>' + '<option value="30">30</option>' + '<option value="40">50</option>' + '<option value="50">100</option>' + '</select><label>筆</label>',

        paginate: {
            previous: "上一頁",
            next: "下一頁",
            first: "第一頁",
            last: "最後一頁"
        },
        zeroRecords: "無資料",
        info: "總共 _PAGES_ 頁，顯示第 _START_ 筆 到第 _END_ 筆。",
        infoEmpty: "無紀錄",
        infoFiltered: "",

    },
    pagingType: "full_numbers"
}

