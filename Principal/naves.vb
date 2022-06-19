Imports Datos
Imports Entidad
Imports System.Data
Imports System.Data.SqlClient
Public Class naves
    Dim obd As New NavesDA
    Dim obe As New NavesEN

    Sub Limpiar()
        txtTipo.Clear()
        txtNombre.Clear()
        txtCaracteristicas.Clear()
        lblId.Text = 0
    End Sub
    Sub Listar_Naves()
        Dim dt As DataTable = obd.Listar_Naves()
        dgvDatos.DataSource = dt
    End Sub
    Private Sub naves_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Listar_Naves()

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If btnNuevo.Text = "Nuevo" Then
            btnNuevo.Text = "Guardar"
            txtCaracteristicas.Enabled = True
        ElseIf btnNuevo.Text = "Guardar" Then

            obe.tipo = txtTipo.Text
            obe.nave = txtNombre.Text
            obe.CaracteristicasNaves = txtCaracteristicas.Text



            obd.Registrar_Naves(obe)


            MsgBox("Registrado Correctamente")

            Listar_Naves()

            Limpiar()
        End If
    End Sub

    Private Sub dgvDatos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatos.CellContentClick

    End Sub

    Private Sub dgvDatos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatos.CellDoubleClick
        Dim i As Integer
        i = dgvDatos.CurrentRow.Index

        txtCaracteristicas.Text = dgvDatos.Rows(i).Cells("3").Value
        lblId.Text = dgvDatos.Rows(i).Cells("0").Value
        txtTipo.Text = dgvDatos.Rows(i).Cells("1").Value
        txtNombre.Text = dgvDatos.Rows(i).Cells("2").Value




    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If btnModificar.Text = "Modificar" Then
            btnModificar.Text = "Actualizar"
            txtCaracteristicas.Enabled = True
        ElseIf btnModificar.Text = "Actualizar" Then

            obe.id_nave = Val(lblId.Text)
            obe.tipo = txtTipo.Text
            obe.nave = txtNombre.Text
            obe.CaracteristicasNaves = txtCaracteristicas.Text

            obd.Modificar_Naves(obe)


            MsgBox("Modificado Correctamente")

            Listar_Naves()
            Limpiar()

        End If
    End Sub



    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        obe.id_nave = Val(lblId.Text)


        obd.Eliminar_Naves(obe)


        MsgBox("Nave Eliminada Correctamente")

        Listar_Naves()

        Limpiar()

    End Sub
End Class