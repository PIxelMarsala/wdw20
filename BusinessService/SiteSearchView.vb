Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices

Namespace BusinessService
    Public Class SiteSearchView
        Public clients As ArrayList

        Public Sub New()
            MyBase.New()
            Me.clients = New ArrayList()
        End Sub

        Private Function createBillClient(ByVal rdr As SqlDataReader) As BusinessService.SiteSearchView.ClientSearchView
            Dim clientSearchView As BusinessService.SiteSearchView.ClientSearchView = New BusinessService.SiteSearchView.ClientSearchView() With
            {
                .client_ID = IntegerType.FromObject(rdr.Item("BillClient_ID"))
            }
            If (Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(rdr.Item("Bill_Last")))) Then
                clientSearchView.last_Name = StringType.FromObject(rdr.Item("Bill_Last"))
                clientSearchView.first_Name = StringType.FromObject(rdr.Item("Bill_First"))
            Else
                clientSearchView.last_Name = ""
                clientSearchView.first_Name = ""
            End If
            If (Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(rdr.Item("Bill_Phone")))) Then
                clientSearchView.phone_Number = StringType.FromObject(rdr.Item("Bill_Phone"))
            Else
                clientSearchView.phone_Number = ""
            End If
            Return clientSearchView
        End Function

        Private Function createBillSite(ByVal rdr As SqlDataReader, ByVal client As BusinessService.SiteSearchView.ClientSearchView) As BusinessService.SiteSearchView.SiteSearchView
            Dim siteSearchView As BusinessService.SiteSearchView.SiteSearchView = New BusinessService.SiteSearchView.SiteSearchView() With
            {
                .site_ID = IntegerType.FromObject(rdr.Item("Site_ID")),
                .no_Stories = StringType.FromObject(rdr.Item("No_Stories")),
                .occ_ClientID = 0,
                .bill_ClientID = IntegerType.FromObject(rdr.Item("BillClient_ID")),
                .address1 = StringType.FromObject(rdr.Item("address1")),
                .zip_Code = StringType.FromObject(rdr.Item("ZipCode")),
                .noteType = IntegerType.FromObject(rdr.Item("Note_Type")),
                .notes = StringType.FromObject(rdr.Item("Notes"))
            }
            client.sites.Add(siteSearchView)
            Return siteSearchView
        End Function

        Private Function createBogusClient(ByVal rdr As SqlDataReader) As BusinessService.SiteSearchView.ClientSearchView
            Return New BusinessService.SiteSearchView.ClientSearchView() With
            {
                .client_ID = 0,
                .last_Name = "Resident"
            }
        End Function

        Private Function createBogusSite(ByVal rdr As SqlDataReader, ByVal client As BusinessService.SiteSearchView.ClientSearchView) As BusinessService.SiteSearchView.SiteSearchView
            Dim siteSearchView As BusinessService.SiteSearchView.SiteSearchView = New BusinessService.SiteSearchView.SiteSearchView() With
            {
                .site_ID = IntegerType.FromObject(rdr.Item("Site_ID")),
                .no_Stories = StringType.FromObject(rdr.Item("No_Stories")),
                .occ_ClientID = 0,
                .bill_ClientID = 0,
                .address1 = StringType.FromObject(rdr.Item("address1")),
                .zip_Code = StringType.FromObject(rdr.Item("ZipCode")),
                .noteType = IntegerType.FromObject(rdr.Item("Note_Type")),
                .notes = StringType.FromObject(rdr.Item("Notes"))
            }
            client.sites.Add(siteSearchView)
            Return siteSearchView
        End Function

        Private Sub createJob(ByVal rdr As SqlDataReader, ByRef site As BusinessService.SiteSearchView.SiteSearchView)
            If (Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(rdr.Item("Job_ID")))) Then
                Dim jobSearchView As BusinessService.SiteSearchView.JobSearchView = New BusinessService.SiteSearchView.JobSearchView() With
                {
                    .job_ID = IntegerType.FromObject(rdr.Item("Job_ID")),
                    .site_ID = IntegerType.FromObject(rdr.Item("Site_ID"))
                }
                If (Information.IsDBNull(RuntimeHelpers.GetObjectValue(rdr.Item("BidHeader_ID")))) Then
                    jobSearchView.bidHeader_ID = 0
                Else
                    jobSearchView.bidHeader_ID = IntegerType.FromObject(rdr.Item("BidHeader_ID"))
                End If
                jobSearchView.start_Date = DateType.FromObject(rdr.Item("Start_Date"))
                jobSearchView.critical = IntegerType.FromObject(rdr.Item("critical"))
                jobSearchView.bill_Amount = DecimalType.FromObject(rdr.Item("Schedule_Amount"))
                jobSearchView.bill_Amount_Integer = IntegerType.FromObject(rdr.Item("Schedule_Amount"))
                jobSearchView.status = StringType.FromObject(rdr.Item("status"))
                jobSearchView.job_Description = StringType.FromObject(rdr.Item("Job_Description"))
                jobSearchView.notes = StringType.FromObject(rdr.Item("Notes"))
                jobSearchView.outsideOnly = IntegerType.FromObject(rdr.Item("Outside_Only"))
                jobSearchView.arBalance = DecimalType.FromObject(rdr.Item("ARBalance"))
                site.jobs.Add(jobSearchView)
            End If
        End Sub

        Private Function createOccClient(ByVal rdr As SqlDataReader) As BusinessService.SiteSearchView.ClientSearchView
            Dim clientSearchView As BusinessService.SiteSearchView.ClientSearchView = New BusinessService.SiteSearchView.ClientSearchView() With
            {
                .client_ID = IntegerType.FromObject(rdr.Item("OccClient_ID"))
            }
            If (Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(rdr.Item("Occ_Last")))) Then
                clientSearchView.last_Name = StringType.FromObject(rdr.Item("Occ_Last"))
                clientSearchView.first_Name = StringType.FromObject(rdr.Item("Occ_First"))
            Else
                clientSearchView.last_Name = ""
                clientSearchView.first_Name = ""
            End If
            If (Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(rdr.Item("Occ_Phone")))) Then
                clientSearchView.phone_Number = StringType.FromObject(rdr.Item("Occ_Phone"))
            Else
                clientSearchView.phone_Number = ""
            End If
            Return clientSearchView
        End Function

        Private Function createOccSite(ByVal rdr As SqlDataReader, ByVal client As BusinessService.SiteSearchView.ClientSearchView) As BusinessService.SiteSearchView.SiteSearchView
            Dim siteSearchView As BusinessService.SiteSearchView.SiteSearchView = New BusinessService.SiteSearchView.SiteSearchView() With
            {
                .site_ID = IntegerType.FromObject(rdr.Item("Site_ID")),
                .no_Stories = StringType.FromObject(rdr.Item("No_Stories")),
                .occ_ClientID = IntegerType.FromObject(rdr.Item("OccClient_ID")),
                .bill_ClientID = 0,
                .address1 = StringType.FromObject(rdr.Item("address1")),
                .zip_Code = StringType.FromObject(rdr.Item("ZipCode")),
                .noteType = IntegerType.FromObject(rdr.Item("Note_Type")),
                .notes = StringType.FromObject(rdr.Item("Notes"))
            }
            client.sites.Add(siteSearchView)
            Return siteSearchView
        End Function

        Public Sub getBillingAddressByAddressLine1(ByVal billingAddress As String)
            Me.processSiteSearchView(Address.getBillingAddressByAddressLine1(billingAddress))
        End Sub

        Public Sub getJobByAddressLine1(ByVal siteAddress As String)
            Me.processSiteSearchView(Address.getJobByAddressLine1(siteAddress))
        End Sub

        Public Sub getJobByAlternatePhone(ByVal alternatePhone As String)
            Me.processSiteSearchView(Job.getJobByAlternatePhone(alternatePhone))
        End Sub

        Public Sub getJobByClientID(ByVal clientId As Integer)
            Me.processSiteSearchView(Job.getJobByClientID(clientId))
        End Sub

        Public Sub getJobByLastName(ByVal lastName As String)
            Me.processSiteSearchView(Job.getJobByLastName(lastName))
        End Sub

        Public Sub getJobByPrimaryPhone(ByVal primaryPhone As String)
            Me.processSiteSearchView(Job.getJobByPrimaryPhone(primaryPhone))
        End Sub

        Public Sub processSiteSearchView(ByVal rdr As SqlDataReader)
            Dim clientSearchView As BusinessService.SiteSearchView.ClientSearchView = Nothing
            Dim clientSearchView1 As BusinessService.SiteSearchView.ClientSearchView = Nothing
            Dim siteSearchView As BusinessService.SiteSearchView.SiteSearchView = Nothing
            Dim siteSearchView1 As BusinessService.SiteSearchView.SiteSearchView
            Dim num As Integer = -1
            Dim num1 As Integer = -1
            Dim num2 As Integer = -1
            Dim flag As Boolean = False
            While rdr.Read()
                flag = True
                If (Not BooleanType.FromObject(ObjectType.BitOrObj(ObjectType.ObjTst(num2, rdr.Item("Site_ID"), False) <> 0, num2 = 0))) Then
                    Me.createJob(rdr, siteSearchView)
                Else
                    num2 = IntegerType.FromObject(rdr.Item("Site_ID"))
                    If (Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(rdr.Item("OccClient_ID")))) Then
                        If (ObjectType.ObjTst(num, rdr.Item("OccClient_ID"), False) = 0) Then
                            siteSearchView1 = Me.createOccSite(rdr, clientSearchView1)
                            siteSearchView = siteSearchView1
                            Me.createJob(rdr, siteSearchView1)
                        Else
                            num = IntegerType.FromObject(rdr.Item("OccClient_ID"))
                            Dim clientSearchView2 As BusinessService.SiteSearchView.ClientSearchView = Me.createOccClient(rdr)
                            clientSearchView1 = clientSearchView2
                            siteSearchView1 = Me.createOccSite(rdr, clientSearchView2)
                            siteSearchView = siteSearchView1
                            Me.createJob(rdr, siteSearchView1)
                            Me.clients.Add(clientSearchView2)
                        End If
                    ElseIf (Information.IsDBNull(RuntimeHelpers.GetObjectValue(rdr.Item("BillClient_ID")))) Then
                        Dim clientSearchView3 As BusinessService.SiteSearchView.ClientSearchView = Me.createBogusClient(rdr)
                        siteSearchView1 = Me.createBogusSite(rdr, clientSearchView3)
                        siteSearchView = siteSearchView1
                        Me.createJob(rdr, siteSearchView1)
                        Me.clients.Add(clientSearchView3)
                    ElseIf (ObjectType.ObjTst(num1, rdr.Item("BillClient_ID"), False) = 0) Then
                        siteSearchView1 = Me.createBillSite(rdr, clientSearchView)
                        siteSearchView = siteSearchView1
                        Me.createJob(rdr, siteSearchView1)
                    Else
                        num1 = IntegerType.FromObject(rdr.Item("BillClient_ID"))
                        Dim clientSearchView4 As BusinessService.SiteSearchView.ClientSearchView = Me.createBillClient(rdr)
                        clientSearchView = clientSearchView4
                        siteSearchView1 = Me.createBillSite(rdr, clientSearchView4)
                        siteSearchView = siteSearchView1
                        Me.createJob(rdr, siteSearchView1)
                        Me.clients.Add(clientSearchView4)
                    End If
                End If
            End While
            rdr.Close()
        End Sub

        Public Class ClientSearchView
            Private m_Last_Name As String

            Private m_First_Name As String

            Private m_Phone_Number As String

            Private m_clientID As Integer

            Private m_sites As ArrayList

            Public Property client_ID As Integer
                Get
                    Return Me.m_clientID
                End Get
                Set(ByVal value As Integer)
                    Me.m_clientID = value
                End Set
            End Property

            Public Property first_Name As String
                Get
                    Return Me.m_First_Name
                End Get
                Set(ByVal value As String)
                    Me.m_First_Name = value
                End Set
            End Property

            Public Property last_Name As String
                Get
                    Return Me.m_Last_Name
                End Get
                Set(ByVal value As String)
                    Me.m_Last_Name = value
                End Set
            End Property

            Public Property phone_Number As String
                Get
                    Return Me.m_Phone_Number
                End Get
                Set(ByVal value As String)
                    Me.m_Phone_Number = value
                End Set
            End Property

            Public Property sites As ArrayList
                Get
                    Return Me.m_sites
                End Get
                Set(ByVal value As ArrayList)
                    Me.m_sites = value
                End Set
            End Property

            Public Sub New()
                MyBase.New()
                Me.m_sites = New ArrayList()
            End Sub
        End Class

        Public Class JobSearchView
            Private m_startDate As DateTime

            Private m_outsideOnly As Integer

            Private m_jobDescription As String

            Private m_notes As String

            Private m_billAmount As Decimal

            Private m_billAmountInteger As Integer

            Private m_status As String

            Private m_critical As Integer

            Private m_ARBalance As Decimal

            Private m_jobID As Integer

            Private m_siteID As Integer

            Private m_bidHeaderID As Integer

            Public Property arBalance As Decimal
                Get
                    Return Me.m_ARBalance
                End Get
                Set(ByVal value As Decimal)
                    Me.m_ARBalance = value
                End Set
            End Property

            Public Property bidHeader_ID As Integer
                Get
                    Return Me.m_bidHeaderID
                End Get
                Set(ByVal value As Integer)
                    Me.m_bidHeaderID = value
                End Set
            End Property

            Public Property bill_Amount As Decimal
                Get
                    Return Me.m_billAmount
                End Get
                Set(ByVal value As Decimal)
                    Me.m_billAmount = value
                End Set
            End Property

            Public Property bill_Amount_Integer As Integer
                Get
                    Return Me.m_billAmountInteger
                End Get
                Set(ByVal value As Integer)
                    Me.m_billAmountInteger = value
                End Set
            End Property

            Public Property critical As Integer
                Get
                    Return Me.m_critical
                End Get
                Set(ByVal value As Integer)
                    Me.m_critical = value
                End Set
            End Property

            Public Property job_Description As String
                Get
                    Return Me.m_jobDescription
                End Get
                Set(ByVal value As String)
                    Me.m_jobDescription = value
                End Set
            End Property

            Public Property job_ID As Integer
                Get
                    Return Me.m_jobID
                End Get
                Set(ByVal value As Integer)
                    Me.m_jobID = value
                End Set
            End Property

            Public Property notes As String
                Get
                    Return Me.m_notes
                End Get
                Set(ByVal value As String)
                    Me.m_notes = value
                End Set
            End Property

            Public Property outsideOnly As Integer
                Get
                    Return Me.m_outsideOnly
                End Get
                Set(ByVal value As Integer)
                    Me.m_outsideOnly = value
                End Set
            End Property

            Public Property site_ID As Integer
                Get
                    Return Me.m_siteID
                End Get
                Set(ByVal value As Integer)
                    Me.m_siteID = value
                End Set
            End Property

            Public Property start_Date As DateTime
                Get
                    Return Me.m_startDate
                End Get
                Set(ByVal value As DateTime)
                    Me.m_startDate = value
                End Set
            End Property

            Public Property status As String
                Get
                    Return Me.m_status
                End Get
                Set(ByVal value As String)
                    Me.m_status = value
                End Set
            End Property

            Public Sub New()
                MyBase.New()
            End Sub
        End Class

        Public Class SiteSearchView
            Private m_address1 As String

            Private m_zipCode As String

            Private m_noStories As Integer

            Private m_noteType As Integer

            Private m_notes As String

            Private m_siteID As Integer

            Private m_occClientID As Integer

            Private m_billClientID As Integer

            Private m_jobs As ArrayList

            Public Property address1 As String
                Get
                    Return Me.m_address1
                End Get
                Set(ByVal value As String)
                    Me.m_address1 = value
                End Set
            End Property

            Public Property bill_ClientID As Integer
                Get
                    Return Me.m_billClientID
                End Get
                Set(ByVal value As Integer)
                    Me.m_billClientID = value
                End Set
            End Property

            Public Property jobs As ArrayList
                Get
                    Return Me.m_jobs
                End Get
                Set(ByVal value As ArrayList)
                    Me.m_jobs = value
                End Set
            End Property

            Public Property no_Stories As String
                Get
                    Return StringType.FromInteger(Me.m_noStories)
                End Get
                Set(ByVal value As String)
                    Me.m_noStories = IntegerType.FromString(value)
                End Set
            End Property

            Public Property notes As String
                Get
                    Return Me.m_notes
                End Get
                Set(ByVal value As String)
                    Me.m_notes = value
                End Set
            End Property

            Public Property noteType As Integer
                Get
                    Return Me.m_noteType
                End Get
                Set(ByVal value As Integer)
                    Me.m_noteType = value
                End Set
            End Property

            Public Property occ_ClientID As Integer
                Get
                    Return Me.m_occClientID
                End Get
                Set(ByVal value As Integer)
                    Me.m_occClientID = value
                End Set
            End Property

            Public Property site_ID As Integer
                Get
                    Return Me.m_siteID
                End Get
                Set(ByVal value As Integer)
                    Me.m_siteID = value
                End Set
            End Property

            Public Property zip_Code As String
                Get
                    Return Me.m_zipCode
                End Get
                Set(ByVal value As String)
                    Me.m_zipCode = value
                End Set
            End Property

            Public Sub New()
                MyBase.New()
                Me.m_jobs = New ArrayList()
            End Sub
        End Class
    End Class
End Namespace