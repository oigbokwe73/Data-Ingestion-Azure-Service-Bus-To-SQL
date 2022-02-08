<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:xs="http://www.w3.org/2001/XMLSchema" exclude-result-prefixes="xs"
    xmlns:json="http://james.newtonking.com/projects/json">
  <xsl:output method="xml" omit-xml-declaration="yes"/>
  <xsl:template match="@*|node()">
    <xsl:copy>
      <xsl:apply-templates select="@*|node()"/>
    </xsl:copy>
  </xsl:template>
  <xsl:template match="//*[local-name()='NewDataSet']">
    <xsl:choose>
      <xsl:when test=".=''">
        <Table json:Array="true">No Records Found</Table>
      </xsl:when>
      <xsl:otherwise>
        <xsl:apply-templates select="@*|node()" />
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <xsl:template match="Table1">
    <Table json:Array="true">
      <xsl:apply-templates select="@*|node()"/>
    </Table>
  </xsl:template>
</xsl:stylesheet>