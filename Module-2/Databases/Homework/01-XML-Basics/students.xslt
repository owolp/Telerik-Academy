<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet version="1.0" 
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
	xmlns:foo="http://www.foo.org/" 
	xmlns:bar="http://www.bar.org">
	<xsl:template match="/">
		<html>
			<body>
				<h2>Students</h2>
				<table border="1">
					<tr bgcolor="#9acd32">
						<th>Name</th>
						<th>Sex</th>
						<th>Dob</th>
						<th>Phone</th>
						<th>Email</th>
						<th>Course</th>
						<th>Speciality</th>
						<th>Faculty Number</th>
						<th>Exams</th>
					</tr>
					<xsl:for-each select="students/students:student">
						<tr>
							<td>
								<xsl:value-of select="name"/>
							</td>
							<td>
								<xsl:value-of select="sex"/>
							</td>
							<td>
								<xsl:value-of select="dob"/>
							</td>
							<td>
								<xsl:value-of select="phone"/>
							</td>
							<td>
								<xsl:value-of select="email"/>
							</td>
							<td>
								<xsl:value-of select="course"/>
							</td>
							<td>
								<xsl:value-of select="speciality"/>
							</td>
							<td>
								<xsl:value-of select="fn"/>
							</td>
							<td>
								<xsl:for-each select="exams/exam">
									<div>
									Name: <xsl:value-of select="name"/> /
									Tutor: <xsl:value-of select="tutor"/> /
									Score: <xsl:value-of select="score"/>
									</div>
								</xsl:for-each>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>