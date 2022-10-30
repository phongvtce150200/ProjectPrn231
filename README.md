# ProjectPrn231 naman001
muốn setup chạy datatable thì làm theo!
--------------Server Side------------------
Tạo file DataTableResponse.cs.
Sửa code trong MedicineController(Đổi lại hàm GetAll).
--------------Client Side-----------------
Add new client side library chọn cndjs nhập vào datatables@ + bản mới nhất.
Add script trong Shared->LayoutDoctor 
<!-- DataTable -->
<head>
    <link href="~/lib/datatables/css/jquery.dataTables.css" rel="stylesheet" />
    <link href="~/lib/datatables/css/dataTables.bootstrap4.css" rel="stylesheet" />

    <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.css" />
</head>
<body>
    <script src="~/lib/jquery/dist/jquery.js"></script>

    <script src="~/lib/datatables/js/jquery.dataTables.js"></script>
    <script src="~/lib/datatables/js/dataTables.bootstrap4.js"></script>

    <script src="~/lib/bootstrap/dist/js/bootstrap.js"></script>
</body>

Add code trong Views->MedicalExam->Index.cshtml
Done!!!!
